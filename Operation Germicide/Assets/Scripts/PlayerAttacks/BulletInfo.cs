using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{

    private GameObject spawner;

    private int damage;
    
    private int hitsLeft;
    private float distanceTilDestroy;
    private bool destroyOnHit;

    private float speed;

    private string[] effects;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.speed = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if collision has an enemy type, damage it

        if (distanceTilDestroy <= 0f)
        {
            Destroy(gameObject);
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

    public void Setup(GameObject spawner, int damage, float distanceTilDestroy, bool destroyOnHit, float speed, string[] effects, int hitsLeft=1)
    {
        this.spawner = spawner;
        this.damage = damage;
        this.hitsLeft = hitsLeft;
        this.distanceTilDestroy = distanceTilDestroy;
        this.destroyOnHit = destroyOnHit;
        this.speed = speed;
        this.effects = effects;
    }

    public GameObject GetSpawner() { return spawner; }
    public int GetDamage() { return damage; }
    public int GetHitsLeft() { return hitsLeft; }
    public float GetDistanceTilDestroy() {  return distanceTilDestroy; }
    public float GetSpeed() { return speed; }
    public string[] GetEffects() {  return effects; }

}
