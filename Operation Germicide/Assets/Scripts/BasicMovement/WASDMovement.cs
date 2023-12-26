using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{

    private AllStats stats;

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 distance;

    private void Start()
    {
        stats = GetComponent<AllStats>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(distance * stats.speed);
    }

}
