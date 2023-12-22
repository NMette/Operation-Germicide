using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 distance;

    // Update is called once per frame
    void Update()
    {
        distance = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(distance * speed);
    }

}
