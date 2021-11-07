using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float MaxSpeed => maxSpeed;
    [SerializeField]
    private float maxSpeed;

    private float speed;
    private Queue<Vector2> targetsQueue = new Queue<Vector2>();
    private Vector2 currentTarget;

    public void AddTarget(Vector2 target)
    {
        targetsQueue.Enqueue(target);
    }
    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Awake()
    {
        currentTarget = transform.position;
        speed = 0f;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, currentTarget) < 0.01f)
        {
            if (targetsQueue.Count == 0)
                return;

            currentTarget = targetsQueue.Dequeue();
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.fixedDeltaTime);
    }
}
