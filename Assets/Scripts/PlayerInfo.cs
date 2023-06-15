using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
    private float health, 
        food,
        warm;
    [SerializeField] private Slider healthSlider, 
        foodSlider,
        warmSlider;
    public bool inWarm = false;
    
    void Start()
    {
        health = 100;
        food = 100;
        warm = 100;
        StartCoroutine(PlayerLoop());
    }

    IEnumerator PlayerLoop()
    {
        while (true)
        {
            if (food > 0) food -= 0.1f;
            if (inWarm && warm < 100) warm += 1;
            else if (warm > 0) warm -= 0.5f;
            if (food <= 0)
            {
                if (health > 0) health -= 0.5f;
            }

            healthSlider.value = health;
            foodSlider.value = food;
            warmSlider.value = warm;
            yield return new WaitForSeconds(1);
        }
    }
    
    
}
