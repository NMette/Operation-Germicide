using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOccasionally : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float cooldown;
    private float gunHeat;

    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject characterBody;

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
            FireBullet();
        }
    }

    void FireBullet()
    {
        BulletInfo clone = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation).GetComponent<BulletInfo>();
        clone.Setup(characterBody, 10, bulletSpeed, 5f, true, null);
    }
}
