using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    private int HealthValue=0;

    public void FixedUpdate(){
        slider.value = HealthValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        HealthValue=health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        HealthValue=health;
    }
    public void IncrementHealth(int increment, bool isDamage){
        if(isDamage){
            HealthValue-=increment;
        }else{
            HealthValue+=increment;
        }
    }
    public int GetHealth(){
        return HealthValue;
    }


}
