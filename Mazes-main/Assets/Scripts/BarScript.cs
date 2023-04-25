using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Gradient staminaGradient;
    private Slider staminaSlider;
    private Image fillImage;

    void Start()
    {
        staminaSlider = GetComponent<Slider>();
        fillImage = staminaSlider.fillRect.GetComponent<Image>();
    }

    void Update()
    {
        float sliderValueNormalized = staminaSlider.value / staminaSlider.maxValue;
        fillImage.color = staminaGradient.Evaluate(sliderValueNormalized);
    }
}