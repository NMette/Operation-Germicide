using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private AllStats baseStats;

    // Start is called before the first frame update
    void Start()
    {
        baseStats.maxHealth = baseStats.baseMaxHealth;
        baseStats.health = baseStats.maxHealth;
        baseStats.speed = baseStats.baseSpeed;
    }

    public void TakeDamage(int damage)
    {
        baseStats.health -= damage;
        if (baseStats.health <= 0f)
        {
            // kill
            Destroy(gameObject); // This is temporary. Will probably implement a death manager to apply effects
        }
    }
}
