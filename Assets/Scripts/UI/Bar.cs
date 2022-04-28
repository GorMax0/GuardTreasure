using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    protected Slider Slider;

    private void Start()
    {
        Slider = GetComponent<Slider>();
    }

    public void OnValueChange(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
