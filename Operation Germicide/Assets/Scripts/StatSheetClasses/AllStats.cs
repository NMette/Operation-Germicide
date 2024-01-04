using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AllStats : MonoBehaviour
{

    // Stats
    public int health;
    public int maxHealth;
    public int baseMaxHealth;

    public float baseSpeed;
    public float speed;

    public int damageResist;
    public int damageNegate;

    // Inventory
    public string[] bacteriaModifiers;

    // Movement
    protected BaseMovement currMovement;

    // Attack
    protected BaseAttack currAttack;

    // Focus Point
    protected BaseFocusPoint currFocus;

    public void TakeDamage(int damage, Damager source)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die(null);
        }
    }

    public void Die(AllStats killer)
    {
        Destroy(gameObject);
    }

    private void SetMovement(BaseMovement newMovement)
    {
        if (currMovement != null)
        {
            currMovement.enabled = false;
        }
        currMovement = newMovement;
        currMovement.enabled = true;
    }

    private void SetAttack(BaseAttack newAttack)
    {
        if (currAttack != null)
        {
            currAttack.enabled = false;
        }
        currAttack = newAttack;
        currAttack.enabled = true;
    }

    private void SetFocus(BaseFocusPoint newFocus)
    {
        if (currFocus != null)
        {
            currFocus.enabled = false;
        }
        currFocus = newFocus;
        currFocus.enabled = true;
    }

}
