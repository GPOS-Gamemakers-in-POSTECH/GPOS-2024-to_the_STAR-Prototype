using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_golem : MonoBehaviour
{
    float attack = 20f; //공격력
    float health = 100f; //체력
    float speed = 0.1f; //골렘 한쪽 다리의 이동 속도
    float walkLength = 3f; //골렘 한쪽 다리가 최대한 이동할 거리
    float golemLegX = 4.5f; //다리가 달릴 지점의 좌표, 골렘 중간 코어부의 중심을 기준으로 우측다리의 좌표
    float golemLegY = -2f;
    float attackX = 4.5f; //공격 오브젝트를 만들 좌표, 기준점은 golemLeg과 동일
    float attackY = -3f;
    float detectionRangeX = 40f; //가로탐지범위
    float detectionRangeY = 5f; //세로탐지범위
    float attackRange = 10f; //공격범위
    float attackAngle = 60f; //공격시 다리를 들 최대 각도
    float attackLegSpeed = 0.3f; //공격시 다리를 들 속도
    int attackDelay = 60; //공격후 이동 딜레이
    int attackTime = 20; //공격지속시간

    int state = 0; //0: normal, 1: alert, 2: stunned, 3: dead
    int delay = 0;
    int walkDelay = 0;
    int direction = 0;
    int walkingState = 3;
    int walkingLegNum = 0;
    float distance = 0f;
    bool alertOn = false;
    bool attackOn = false;
    Vector3 moveVector = Vector3.right;

    Transform player;
    SpriteRenderer spriteRenderer;
    GameObject attackObj;
    GameObject leftLeg;
    GameObject rightLeg;
    Animator animator;

    public GameObject golemLeg; //golemLeg 스크립트가 들어간 것으로 설정해야함
    public GameObject enemyAttack; //dustpanAttack 스크립트가 들어간 것으로 설정해야함

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("player").transform;
        gameObject.tag = "enemy";
        animator = GetComponent<Animator>();

        leftLeg = Instantiate(golemLeg, transform.position + new Vector3(-1 * golemLegX, golemLegY, 0), Quaternion.identity);
        rightLeg = Instantiate(golemLeg, transform.position + new Vector3(golemLegX, golemLegY, 0), Quaternion.identity);
        rightLeg.GetComponent<SpriteRenderer>().flipX = true;
    }

    void Update()
    {
        if (health <= 0) { state = 3; }
        delay--;

        switch (state)
        {
            case 0: Move(); break;
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

    void Move()
    {
        alertOn = (Math.Abs(player.transform.position.x - transform.position.x) < detectionRangeX) && (Math.Abs(player.transform.position.y - transform.position.y) < detectionRangeY); //alert판정

        if (alertOn) //alert상태로의 변경
        {
            if (state != 1) { delay = 0; }
            state = 1;
            animator.SetBool("bool_alert", true);
        }
        else
        {
            state = 0;
            animator.SetBool("bool_alert", false);
        }

        distance = Vector3.Distance(transform.position, player.transform.position);

        if (direction != 0) { animator.SetBool("bool_move", true); } //움직임 애니메이션
        else { animator.SetBool("bool_move", false); }

        if (walkingState >= 3) //움직이는 방향의 설정
        {
            if (alertOn) //alert상태일 경우의 설정
            {
                if (player.transform.position.x - this.transform.position.x < -1 * attackRange / 4) { direction = -1; }
                else if (player.transform.position.x - this.transform.position.x > attackRange / 4) { direction = 1; }
                else { direction = 0; }
            }
            else //idle상태일 경우의 설정
            {
                direction = UnityEngine.Random.Range(-1, 4);
                if(direction!=1 && direction != -1) { direction = 0; }
            }
        }

        if (!attackOn)
        {
            switch (walkingState) //0: 앞쪽다리 들어옮김 1: 잠시 정지 2: 뒷쪽다리 들어옮김 3, 4: 휴식
            {
                case 0:
                    if (direction == -1) { leftLeg.transform.position += new Vector3(-1 * speed, -1 * speed / walkLength * Math.Sign(walkingLegNum * 2 - walkLength / speed), 0); }
                    else if (direction == 1) { rightLeg.transform.position += new Vector3(speed, -1 * speed / walkLength * Math.Sign(walkingLegNum * 2 - walkLength / speed), 0); }
                    this.transform.position += new Vector3(direction * speed / 2, 0, 0);
                    if (walkingLegNum>=walkLength/speed) { walkDelay = (int)(walkLength / speed); walkingLegNum = 0; walkingState = 1; }
                    walkingLegNum++;
                    break;
                case 1:
                    walkDelay--;
                    if (walkDelay == 0) { walkingState = 2; }
                    break;
                case 2:
                    if (direction == -1) { rightLeg.transform.position += new Vector3(-1 * speed, -1 * speed / walkLength * Math.Sign(walkingLegNum * 2 - walkLength / speed), 0); }
                    else if (direction == 1) { leftLeg.transform.position += new Vector3(speed, -1 * speed / walkLength * Math.Sign(walkingLegNum * 2 - walkLength / speed), 0); }
                    this.transform.position += new Vector3(direction * speed / 2, 0, 0);
                    if (walkingLegNum > walkLength / speed) { walkingLegNum = 0; walkingState = 3; }
                    walkingLegNum++;
                    break;
                case 3:
                    leftLeg.transform.position = transform.position + new Vector3(-1 * attackX, golemLegY, 0);
                    rightLeg.transform.position = transform.position + new Vector3(golemLegX, golemLegY, 0);
                    delay = 60;
                    walkingState = 4;
                    break;
                case 4:
                    if (delay <= 0 && distance >= attackRange) { walkingState = 0; }
                    break;
            }
        }

    }

    void Attack()
    {
        
        if (!attackOn && delay <=0 && distance < attackRange && walkingState >= 3) { attackOn = true; delay = 0; }

        if (attackOn)
        {
            if (player.transform.position.x - this.transform.position.x < 0) //왼쪽에 있을 때 공격
            {
                leftLeg.transform.Rotate(0f, 0f, -1 * attackLegSpeed);
            }
            else //오른쪽에 있을 때 공격
            {
                rightLeg.transform.Rotate(0f, 0f, attackLegSpeed);
            }

            if(Math.Abs(attackLegSpeed * delay) >= attackAngle) //다리를 순식간에 내려놓으며 공격오브젝트 생성
            {
                if (player.transform.position.x - this.transform.position.x < 0) { leftLeg.transform.Rotate(0f, 0f, -1 * attackLegSpeed * delay); }
                else { rightLeg.transform.Rotate(0f, 0f, attackLegSpeed * delay); }
                attackObj = Instantiate(enemyAttack, transform.position 
                    + new Vector3((player.transform.position.x - this.transform.position.x)/Math.Abs(player.transform.position.x - this.transform.position.x) * attackX, attackY, 0), Quaternion.Euler(0f, 0f, 0f));
                attackObj.GetComponent<scrt_enemyAttack>().attack = attack;
                attackObj.GetComponent<scrt_enemyAttack>().enemyCode = 0;
                attackObj.GetComponent<scrt_enemyAttack>().lifeDuration = attackTime;
                delay = attackDelay;
                animator.SetTrigger("trigger_attack");
                attackOn = false;
            }
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
        walkingState = 3;
        leftLeg.transform.position = transform.position + new Vector3(-1 * golemLegX, golemLegY, 0);
        rightLeg.transform.position = transform.position + new Vector3(golemLegX, golemLegY, 0);
    }
}
