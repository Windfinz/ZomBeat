using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;

    public float regen;
    public float health;
    public float maxHealth;

    private GameManager manager;

    private void Start()
    {
        health = maxHealth;
        manager = FindObjectOfType<GameManager>();
        
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            manager.LoseGame();
        }

    }

    private void RegenHealth()
    {
        if (health < maxHealth)
        {
            health += regen * Time.deltaTime;
            if(health > maxHealth)
            {
                health = maxHealth;
            }

        }
    }

    private void Update()
    {
        HealthBar();
        RegenHealth();
    }

    private void HealthBar()
    {
        healthBar.fillAmount = health / maxHealth;
    }

}
