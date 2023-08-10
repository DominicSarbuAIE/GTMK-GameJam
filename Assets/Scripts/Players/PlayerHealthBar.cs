using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image healthBar;

    public void SetMaxHealth(int _health)
    {
        healthBar.fillAmount = _health;
    }

    public void ChangeHealthBar(int _damage)
    {
        healthBar.fillAmount -= 0.1f;
    }
}
