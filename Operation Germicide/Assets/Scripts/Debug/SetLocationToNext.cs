using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocationToNext : MonoBehaviour
{

    [SerializeField] private ObjectLocationPoint objectToLookAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToLookAt.GetNextLocation();
    }
}
