using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BarrelFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float cooldown;
    private float gunHeat;

    [SerializeField] private float bulletSpeed;

    private GameObject characterBody;

    // Start is called before the first frame update
    void Start()
    {
        characterBody = FindFirstObjectByType<PlayerType>().gameObject;
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
            FireBullet();
        }
    }

    void FireBullet()
    {
        BulletInfo clone = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation).GetComponent<BulletInfo>();
        clone.Setup(characterBody, 10, bulletSpeed, 5f, true, null);
    }

}
