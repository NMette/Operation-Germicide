using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BarrelFire : MonoBehaviour
{

    [SerializeField] private readonly float cooldown;
    private float gunHeat;

    private List<BulletInfo> bullets;
    private float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new();
        gunHeat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        } else if (Input.GetMouseButtonDown(0))
        {
            gunHeat = cooldown;
            FireBullet();
        }
    }

    void FireBullet()
    {
        
    }

}
