using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFocusPoint : MonoBehaviour
{

    [SerializeField] protected Rigidbody2D objectToLookAt;
    [SerializeField] protected float rotateTime;

}
