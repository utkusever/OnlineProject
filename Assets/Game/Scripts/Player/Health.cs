using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] float health;
    [SerializeField] HealthBar healthBar;
    private float maxHealth = 100;
    public void ApplyDamage(float value)
    {
        health -= value;
        if (health >= maxHealth) health = maxHealth;
        healthBar.UpdateBar(health);
        if (IsDead())
        {
            this.gameObject.SetActive(false);
        }
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public bool IsDead()
    {
        return health <= 0;
    }

}
