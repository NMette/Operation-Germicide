using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToMouse : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(rb.transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
