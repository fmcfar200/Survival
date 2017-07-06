using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

    GameObject player;
    Health health;
    PlayerCombat combat;

    public Image healthBar;
    public Text ammoText;


    void Start()
    {
        InitPlayerComponents();
    }

    void Update()
    {
        UpdateUI();

    }

    void UpdateUI()
    {
        healthBar.fillAmount = health.currentHealth / 100.0f;
        ammoText.text = combat.clip.ToString() + "/" + combat.ammo.ToString();
    }

    void InitPlayerComponents()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            health = player.GetComponent<Health>();
            combat = player.GetComponent<PlayerCombat>();
        }
        else
        {
            Debug.LogError("Player Not Found!");
        }
    }

}
