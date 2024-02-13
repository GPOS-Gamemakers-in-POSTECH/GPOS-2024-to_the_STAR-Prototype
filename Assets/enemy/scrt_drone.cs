using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class scrt_drone : MonoBehaviour
{
    //능력치
    float attack = 20f; //공격력
    float health = 100f; //체력
    float speed = 2f; //이동속력
    float detectionRangeX = 20f; //가로탐지범위
    float detectionRangeY = 10f; //세로탐지범위
    float attackRange = 10f; //공격범위
    float bulletSpeed = 5f; //총알의 속도
    int attackDelay = 60; //공격딜레이
    int attackTime = 20; //공격지속시간
    public int floorLoc = 0; //딛고 있는 바닥의 위치, 0: 바닥, 1: 왼쪽벽 2: 천장 3: 오른쪽벽

    int state = 0; //0: normal, 1: alert, 2: stunned, 3: dead
    int delay = 0;
    int direction = 0;
    float distance = 0f;
    bool alertOn = false;
    Vector3 moveVector = Vector3.right;

    Transform player;
    SpriteRenderer spriteRenderer;
    GameObject attackObj;
    Animator animator;
    public GameObject enemyAttack; //dustpanAttack 스크립트가 들어간 것으로 설정해야함

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("player").transform;
        gameObject.tag = "enemy";
        animator = GetComponent<Animator>();

        if (floorLoc % 2 == 0) { moveVector = Vector3.right; }
        else { moveVector = Vector3.up; }

        if (floorLoc != 0) { spriteRenderer.transform.localRotation = Quaternion.Euler(0f, 0f, (4 - floorLoc) * 90f); }

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
            case 3: animator.SetBool("bool_death", true); break;
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall") //벽과 충돌
        {
            if (state == 0) { direction *= -1; } //idle 상태일 경우 반대로 돌아감
            else if (state == 1) { direction = 0; } //추격 중일 경우 벽에 걸려있음
        }
    }

    void Move()
    {

        if (floorLoc % 2 == 0) //x방향으로 움직일 경우 (바닥, 천장)
        {
            alertOn = (Math.Abs(player.transform.position.x - this.transform.position.x) < detectionRangeX) && (Math.Abs(player.transform.position.y - this.transform.position.y) < detectionRangeY);
            //바닥이면 0, 천장이면 2이므로 floorLoc-1의 부호가 음수면 바닥, 양수면 천장. 이 부호와 플레이어와 자신의 y좌표 차이의 부호가 같아야함
            if(floorLoc-1 != Math.Sign(player.transform.position.y - this.transform.position.y)) { alertOn = false; }
            if (direction != 0) { spriteRenderer.flipX = (direction == (floorLoc * -1) + 1); }
        }
        else //y방향으로 움직일 경우 (벽)
        {
            alertOn = (Math.Abs(player.transform.position.y - this.transform.position.y) < detectionRangeX) && (Math.Abs(player.transform.position.x - this.transform.position.x) < detectionRangeY);
            //마찬가지로 왼쪽이 1, 오른쪽이 3, -2의 부호와 x좌표 차이의 부호가 같아야함
            if (floorLoc - 2 != Math.Sign(player.transform.position.x - this.transform.position.x)) { alertOn = false; }
            if (direction != 0) { spriteRenderer.flipX = (direction == floorLoc - 2); }
        }

        transform.Translate(moveVector * direction * speed * Time.deltaTime, Space.World);

        if (direction != 0) { animator.SetBool("bool_move", true); }
        else { animator.SetBool("bool_move", false); }
        
        distance=Vector3.Distance(transform.position, player.transform.position);
        if (alertOn) {
            if (state != 1) { delay = 0; }
            state = 1;
            animator.SetBool("bool_alert", true);
        }
        else { 
            state = 0;
            animator.SetBool("bool_alert", false);
        }
    }

    void Attack()
    {

        if (floorLoc % 2 == 0)
        {
            if (player.transform.position.x - this.transform.position.x < -1 * attackRange / 4) { direction = -1; }
            else if (player.transform.position.x - this.transform.position.x > attackRange / 4) { direction = 1; }
            else { direction = 0; }
        }
        else
        {
            if (player.transform.position.y - this.transform.position.y < -1 * attackRange / 4) { direction = -1; }
            else if (player.transform.position.y - this.transform.position.y > attackRange / 4) { direction = 1; }
            else { direction = 0; }
        }

        if (distance < attackRange && delay <= 0)
        {
            attackObj = Instantiate(enemyAttack, transform.position, Quaternion.Euler(0f, 0f, (4 - floorLoc) * 90f));
            attackObj.GetComponent<scrt_enemyAttack>().attack = attack;
            attackObj.GetComponent<scrt_enemyAttack>().enemyCode = 1;
            attackObj.GetComponent<scrt_enemyAttack>().bulletSpeed = bulletSpeed;
            attackObj.GetComponent<scrt_enemyAttack>().lifeDuration = attackTime;
            delay = attackDelay;
            animator.SetTrigger("trigger_attack");
        }

    }

    public void Damage(float damage) //플레이어 오브젝트에서 이 함수를 통해 데미지를 입힐 수 있음. enemy tag를 찾아서 공격과 충돌판정이 나는 경우 호출하면 됨
    {
        health -= damage;
        animator.SetTrigger("trigger_getAttacked");
    }

    public void GetStunned(int time) //time 만큼 스턴에 걸리게 함. time프레임만큼 스턴에 걸림
    {
        state = 2;
        delay = time;
        animator.SetTrigger("trigger_getStunned");
    }
}
