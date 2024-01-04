using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{

    [SerializeField] protected GameObject bulletPrefab;

    [SerializeField] protected float cooldown;
    protected float gunHeat;

    [SerializeField] protected float bulletSpeed;

    [SerializeField] protected AllStats owner;

    protected abstract void Fire();

}