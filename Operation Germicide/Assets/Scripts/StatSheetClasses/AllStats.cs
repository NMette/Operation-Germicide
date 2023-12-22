using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AllStats : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public int baseMaxHealth;

    public float baseSpeed;
    public float speed;

    public int damageResist;
    public int damageNegate;

    public string[] bacteriaModifiers;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            // kill
            Destroy(gameObject); // This is temporary. Will probably implement a death manager to apply effects
        }
    }

}
