using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class BulletInfo : Damager
{
    protected override void Movement()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected override void PhysicsMovement()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D collision)
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
    }*/

    protected override void DamageEntity(AllStats entity)
    {
        entity.TakeDamage(damage, this);
    }

    protected override void CheckDestruct()
    {
        if (destroyOnHit)
        {
            hitsLeft -= 1;
            if (hitsLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
