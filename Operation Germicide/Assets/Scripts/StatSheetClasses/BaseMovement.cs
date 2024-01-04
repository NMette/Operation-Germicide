using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{

    [SerializeField] protected AllStats owner;

    public void SetOwner(AllStats owner)
    {
        this.owner = owner;
    }

}
