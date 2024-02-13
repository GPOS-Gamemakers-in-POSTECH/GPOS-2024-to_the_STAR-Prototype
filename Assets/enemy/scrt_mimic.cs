using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_mimic : MonoBehaviour
{
    float attack = 20f; //공격력
    float speed = 2f; //이동속력
    float detectionRangeX = 20f; //가로탐지범위
    float detectionRangeY = 5f; //세로탐지범위
    float attackRange = 4f; //공격범위
    int attackDelay = 60; //공격딜레이
    int attackTime = 20; //공격지속시간

    int health = 2;

    Transform player;
    SpriteRenderer spriteRenderer;
    GameObject attackObj;
    Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("player").transform;
        gameObject.tag = "enemy";
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void Move()
    {

    }

    void Attack()
    {
        if(health == 2)
        {

        }
        else if(health == 1)
        {

        }
    }

    void Damage(float damage) //데미지를 넣는 함수, 그러나 damage인자는 통일성을 위한 값이며 한대 맞으면 Exposed, 두대 맞으면 Dead가 되고 damage는 쓰지 않음
    {
        health--;

    }

}
