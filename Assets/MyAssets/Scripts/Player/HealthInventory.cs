using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthInventory : MonoBehaviour
{
    //health variables
    Health health;
    float maxHealth;
    float currentHealth;

    int healthPacks;
    public Text healthText;


    void Start()
    {
        health = GetComponent<Health>();
        healthPacks = 1;
    }

    void Update()
    {
        maxHealth = health.maxHealth;
        currentHealth = health.currentHealth;

        healthText.text = healthPacks.ToString();

        if (Input.GetKeyDown("joystick button 4"))
        {
            if (currentHealth < maxHealth && healthPacks > 0)
            {
                healthPacks--;
                health.AddHealth(35f);

            }
        }
    }

   
}
