using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public float health;
    public float startHealth = 100f;
    [Header("unity stuff")]
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        return;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
