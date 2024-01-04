using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BarrelFire : BaseAttack
{

    // Start is called before the first frame update
    void Start()
    {
        owner = FindFirstObjectByType<PlayerType>();
        gunHeat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunHeat > 0f)
        {
            gunHeat -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0) && gunHeat <= 0f)
        {
            gunHeat = cooldown;
            Fire();
        }
    }

    protected override void Fire()
    {
        BulletInfo clone = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation).GetComponent<BulletInfo>();
        clone.Setup(owner, 10, bulletSpeed, 5f, true, null);
    }
}
