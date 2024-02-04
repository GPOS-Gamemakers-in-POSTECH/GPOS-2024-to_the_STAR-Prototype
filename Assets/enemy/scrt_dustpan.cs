using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class scrt_dustpan : MonoBehaviour
{
    //능력치
    float attack = 20f; //공격력
    float health = 100f; //체력
    float speed = 2f; //이동속력
    float detectionRange = 20f; //탐지범위
    float attackRange = 4f; //공격범위
    int attackDelay = 60; //공격딜레이
    int attackTime = 20; //공격지속시간

    int state = 0; //0: normal, 1: alert, 2: stunned, 3: dead
    int delay = 0;
    int direction = 0;
    float distance = 0f;

    Transform player;
    SpriteRenderer spriteRenderer;
    GameObject attackObj;
    public GameObject enemyAttack; //dustpanAttack 스크립트가 들어간 것으로 설정해야함

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("player").transform;
        gameObject.tag = "enemy";
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { state = 3; }
        delay--;

        switch(state)
        {
            case 0: 
                Move();
                if (delay <= 0) //일정 주기마다 움직이는 방향 변경
                {
                    delay = UnityEngine.Random.Range(120, 601);
                    direction = UnityEngine.Random.Range(-1, 2);
                }
                break;
            case 1: Move(); Attack(); break;
            case 2:
                if (delay <= 0)
                {
                    state = 0;
                }
                    break;
            case 3: break;
        }

        
    }

    void Move()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);
        if (direction != 0) { spriteRenderer.flipX = (direction == 1); }
        
        distance=Vector3.Distance(transform.position, player.transform.position);
        if (distance < detectionRange && Math.Abs(player.transform.position.y-this.transform.position.y)<detectionRange/2) {
            if (state != 1) { delay = 0; }
            state = 1; 
        }
        else { state = 0; }
    }

    void Attack()
    {
        if (player.transform.position.x - this.transform.position.x < -1*attackRange/4) { direction = -1; }
        else if (player.transform.position.x - this.transform.position.x > attackRange/4) { direction = 1; }
        else { direction = 0; }

        if (distance < attackRange && delay <= 0)
        {
            attackObj = Instantiate(enemyAttack, transform.position, Quaternion.identity);
            attackObj.GetComponent<scrt_enemyAttack>().attack = attack;
            attackObj.GetComponent<scrt_enemyAttack>().enemyCode = 0;
            delay = attackDelay;
        }
        if (delay <= attackDelay - attackTime)
        {
            Destroy(attackObj);
        }

    }

    public void Damage(float damage) //플레이어 오브젝트에서 이 함수를 통해 데미지를 입힐 수 있음. enemy tag를 찾아서 공격과 충돌판정이 나는 경우 호출하면 됨
    {
        health -= damage;
    }

    public void GetStunned(int time) //time 만큼 스턴에 걸리게 함. time프레임만큼 스턴에 걸림
    {
        state = 2;
        delay = time;
    }
}
