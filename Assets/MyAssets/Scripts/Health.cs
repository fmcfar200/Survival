using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float currentHealth;
    float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    public void Death()
    {
        if (gameObject.tag == "Player")
        {
            print("Dead");
        }
    }
}
