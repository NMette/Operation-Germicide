using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform toFollow;

    private void Start()
    {
        toFollow = FindFirstObjectByType<PlayerType>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(toFollow.position.x, toFollow.position.y, transform.position.z);
    }
}
