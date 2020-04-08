using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public Slider HPSlider;

    public void SetMaxHealth(int health)
    {
        HPSlider.maxValue = health;
        HPSlider.value = health;
    }

    public void SetHealth(int health)
    {
        HPSlider.value = health;
    }

}
