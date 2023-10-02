using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{

    private GameObject spawner;

    private int damage;
    
    private int hitsLeft;
    private float timeToDestroy;
    private bool destroyOnHit;

    private float speed;

    private string[] effects;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if collision has an enemy type, damage it

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
        this.damage = damage;
        this.speed = speed;
        this.timeToDestroy = timeToDestroy;
        this.hitsLeft = hitsLeft;
        this.destroyOnHit = destroyOnHit;
        this.effects = effects;
    }

    public GameObject GetSpawner() { return spawner; }
    public int GetDamage() { return damage; }
    public int GetHitsLeft() { return hitsLeft; }
    public float GetSpeed() { return speed; }
    public string[] GetEffects() {  return effects; }

}
