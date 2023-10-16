using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerType : AllStats
{

    int xp;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = baseMaxHealth;
        health = maxHealth;
        speed = baseSpeed;
    }
}
