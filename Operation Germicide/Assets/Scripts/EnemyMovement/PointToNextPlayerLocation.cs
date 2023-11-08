using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToNextPlayerLocation : MonoBehaviour
{

    public Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = FindFirstObjectByType<PlayerType>().GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
