using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PredictiveAim : MonoBehaviour
{

    [SerializeField] private Rigidbody2D objectToLookAt;
    [SerializeField] private float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        if (!GetPredicted(objectToLookAt.transform.position, transform.position, objectToLookAt.velocity, 10, out Vector2 direction))
        {
            // Do something else to change the rotation, but not sure what yet
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time / rotateSpeed);
    }

    bool GetPredicted(Vector2 a, Vector2 b, Vector2 vA, float sB, out Vector2 result)
    {
        Vector2 aToB = b - a;
        float dC = aToB.magnitude;
        float alpha  = Vector2.Angle(aToB, vA) * Mathf.Deg2Rad;
        float sA = vA.magnitude;
        float r = sA / sB;
        if (SolveQuadratic(1 - r * r, 2 * r * dC * Mathf.Cos(alpha), -(dC * dC), out float root1, out float root2) == 0)
        {
            result = Vector2.zero;
            return false;
        }

        float dA = Mathf.Max(root1, root2);
        float t = dA / sB;
        Vector2 c = a + vA * t;
        result = (c - b).normalized;
        return true;
    }

    private static int SolveQuadratic(float a, float b, float c, out float x1, out float x2)
    {
        float determ = Mathf.Pow(b, 2) - (4 * a * c);
        if (determ < 0)
        {
            x1 = float.PositiveInfinity;
            x2 = -x1;
            return 0;
        }
        float denom = 2 * a;
        x1 = (-b + Mathf.Sqrt(determ)) / denom;
        x2 = (-b - Mathf.Sqrt(determ)) / denom;
        return (determ > 0) ? 2 : 1;
    }

}
