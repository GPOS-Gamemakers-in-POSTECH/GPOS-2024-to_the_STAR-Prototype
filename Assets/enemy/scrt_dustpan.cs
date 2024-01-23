using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class scrt_dustpan : MonoBehaviour
{
    int attack = 20;
    float health = 100;
    int delay = 30;
    int speed = 2;
    int state = 0; //0: normal, 1: alert, 2: stunned, 3: dead
    int direction = 0;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { state = 3; }

        switch(state)
        {
            case 0: delay--; Move(); break;
            case 1: Move(); Attack(); break;
            case 2: break;
            case 3: break;
        }

        if (delay == 0) //일정 주기마다 움직이는 방향 변경
        {
            delay = UnityEngine.Random.Range(120, 601);
            direction = UnityEngine.Random.Range(-1, 2);
        }
    }

    void Move()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);
        if (direction != 0) { spriteRenderer.flipX = (direction == 1); }
    }

    void Attack()
    {
        
    }

    void Damage(float damage)
    {
        health -= damage;
    }
}
