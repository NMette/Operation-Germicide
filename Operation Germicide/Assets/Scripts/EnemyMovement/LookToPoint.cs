using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPoint : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;

    private PointToPlayer mPlayer;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GetComponent<PointToPlayer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = mPlayer.GetPlayerLocation() - rb.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * rotateSpeed);
        
        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
    }
}
