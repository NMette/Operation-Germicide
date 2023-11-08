using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlayer : MonoBehaviour
{

    private Transform playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = FindFirstObjectByType<PlayerType>().GetComponentInParent<Transform>();
    }

    public Vector3 GetPlayerLocation()
    {
        return playerLocation.position;
    }
}
