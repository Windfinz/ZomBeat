using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;

    public float health;
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            
        }

    }

    private void Update()
    {
        HealthBar();
    }

    private void HealthBar()
    {
        healthBar.fillAmount = health / maxHealth;
    }

}
