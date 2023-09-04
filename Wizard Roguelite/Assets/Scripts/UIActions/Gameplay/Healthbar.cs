using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public FloatReference Variable;
    public FloatReference Max;

    public Slider slider;

    public void Start()
    {
        slider.maxValue = Max.Value;
        slider.value = Max.Value;
    }

    public void Update()
    {
        slider.maxValue = Max.Value;
        slider.value = Variable.Value;
    }
}
