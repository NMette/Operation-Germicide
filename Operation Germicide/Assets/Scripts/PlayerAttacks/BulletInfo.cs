using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class BulletInfo : Damager
{

    private GameObject spawner;
    private String spawnerType;
    
    private int hitsLeft;
    private float timeToDestroy;
    private bool destroyOnHit;

    private float speed;

    private string[] effects;

    private bool setupRan = false;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!setupRan)
        {
            return;
        }
        PlayerType curr = null; EnemyType curr2 = null;
        if (collision.gameObject.TryGetComponent<PlayerType>(out curr) && !spawnerType.Equals("PlayerType"))
        {
            curr.TakeDamage(damage, this);
        } else if (collision.gameObject.TryGetComponent<EnemyType>(out curr2) && !spawnerType.Equals("EnemyType"))
        {
            curr2.TakeDamage(damage, this);
        } else
        {
            return;
        }

        if (destroyOnHit)
        {
            hitsLeft -= 1;
            if (hitsLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(GameObject spawner, int damage, float speed, float timeToDestroy, bool destroyOnHit, string[] effects, int hitsLeft=1)
    {
        this.spawner = spawner;
        PlayerType test;
        EnemyType test2;
        if (spawner.TryGetComponent<PlayerType>(out test))
        {
            this.spawnerType = "PlayerType";
        } else if (spawner.TryGetComponent<EnemyType>(out test2))
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
    }

    public GameObject GetSpawner() { return spawner; }
    public int GetHitsLeft() { return hitsLeft; }
    public float GetSpeed() { return speed; }
    public string[] GetEffects() {  return effects; }

}
