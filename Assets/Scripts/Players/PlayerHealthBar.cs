using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider _slider;

    public void SetMaxHealth(int _health)
    {
        _slider.maxValue = _health;
        _slider.value = _health;
    }

    public void ChangeHealthBar(int _health)
    {
        _slider.value = _health;
    }
}
