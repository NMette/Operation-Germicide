using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOccasionally : BaseAttack
{

    // Start is called before the first frame update
    void Start()
    {
        gunHeat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunHeat > 0f)
        {
            gunHeat -= Time.deltaTime;
        }
        if (gunHeat <= 0f)
        {
            gunHeat = cooldown + Random.Range(-2, 3);
            Fire();
        }
    }

    protected override void Fire()
    {
        BulletInfo clone = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation).GetComponent<BulletInfo>();
        clone.Setup(owner, 10, bulletSpeed, 5f, true, null);
    }
}
