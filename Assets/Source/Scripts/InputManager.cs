using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private GameObject redCirclePrefab;

    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            var target = cam.ScreenToWorldPoint(Input.mousePosition);
            ball.AddTarget(target);
            VisualizeMouseClickPoint(target);
        }
    }
    private void VisualizeMouseClickPoint(Vector2 point)
    {
        Instantiate(redCirclePrefab, point, Quaternion.identity);
    }
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
