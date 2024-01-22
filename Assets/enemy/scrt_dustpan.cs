using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scrt_dustpan : MonoBehaviour
{
    int attack = 20;
    float health = 100;
    int delay = 30;
    int speed = 10;
    int state = 0; //0: normal, 1: alert, 2: stunned, 3: dead
    int direction = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay--;
        if (health <= 0) { state = 3; }
    }

    void Move()
    {
        if (state != 3) { transform.Translate(Vector3.right*direction*speed * Time.deltaTime, Space.World); }
    }

    void Attack()
    {

    }

    void Damage()
    {

    }
}
