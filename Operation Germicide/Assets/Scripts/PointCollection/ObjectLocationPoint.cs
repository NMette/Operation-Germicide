using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectLocationPoint : MonoBehaviour
{

    public Rigidbody2D objectRB;
    public Vector3 nextLocation;

    private void Start()
    {
        objectRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectRB != null)
        {
            nextLocation = transform.position + (Vector3)objectRB.velocity;
        }
    }

    public Vector3 GetLocation()
    {
        return transform.position;
    }

    public Vector3 GetNextLocation()
    {
        if (objectRB != null)
            return nextLocation;
        return transform.position;
    }

}
