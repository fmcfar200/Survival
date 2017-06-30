using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float currentHealth;
    public bool dead;
    float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
        dead = false;
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

        DestroyComponenents();

        dead = true;
    }

    void DestroyComponenents()
    {
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(GetComponent<EnemyMovement>());
        Destroy(GetComponent<EnemyCombat>());



    }
}
