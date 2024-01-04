using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damager : MonoBehaviour
{

    [SerializeField] protected AllStats owner;

    protected int damage;
    protected string[] effects;

    protected int hitsLeft;
    protected float timeToDestroy;
    protected bool destroyOnHit;

    protected float speed;

    protected string spawnerType;

    protected bool setupRan = false;

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        PhysicsMovement();
    }

    public int GetDamage() { return damage; }
    public AllStats GetOwner() { return owner; }
    public int GetHitsLeft() { return hitsLeft; }
    public float GetSpeed() { return speed; }
    public string[] GetEffects() { return effects; }

    public void Setup(AllStats owner, int damage, float speed, float timeToDestroy, bool destroyOnHit, string[] effects, int hitsLeft = 1)
    {
        this.owner = owner;
        PlayerType test;
        EnemyType test2;
        if (owner.gameObject.TryGetComponent<PlayerType>(out test))
        {
            this.spawnerType = "PlayerType";
        }
        else if (owner.gameObject.TryGetComponent<EnemyType>(out test2))
        {
            this.spawnerType = "EnemyType";
        }
        this.damage = damage;
        this.speed = speed;
        this.timeToDestroy = timeToDestroy;
        this.hitsLeft = hitsLeft;
        this.destroyOnHit = destroyOnHit;
        this.effects = effects;
        this.setupRan = true;

        if (timeToDestroy > 0)
        {
            Destroy(gameObject, timeToDestroy);
        }
    }

    protected abstract void Movement();
    protected abstract void PhysicsMovement();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckCanDamage(collision))
        {
            return;
        }
        DamageEntity(collision.GetComponent<AllStats>());
        CheckDestruct();
    }

    protected bool CheckCanDamage(Collider2D collision)
    {
        if (!setupRan)
        {
            return false;
        }
        PlayerType curr = null; EnemyType curr2 = null;
        if (collision.gameObject.TryGetComponent<PlayerType>(out curr) && !spawnerType.Equals("PlayerType"))
        {
            return true;
        }
        else if (collision.gameObject.TryGetComponent<EnemyType>(out curr2) && !spawnerType.Equals("EnemyType"))
        {
            return true;
        }
        else
        {
            return false;
        }
        /*
         * Need to add a check for walls once walls are implemented
         */
    }

    protected abstract void DamageEntity(AllStats entity);

    protected abstract void CheckDestruct();

}
