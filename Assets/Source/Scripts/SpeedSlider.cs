using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Text speedText;

    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = ball.MaxSpeed;
        slider.onValueChanged.AddListener((value) =>
            {
                ball.ChangeSpeed(value);
                speedText.text = value.ToString("0.00");
            });
        slider.onValueChanged.Invoke(0f);
    }
}
