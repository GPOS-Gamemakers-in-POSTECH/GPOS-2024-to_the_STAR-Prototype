using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class scrt_player : MonoBehaviour
{
    float health = 100f;

    public float reviveX;
    public float reviveY;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "player";
        animator = GetComponent<Animator>();
        reviveX = transform.position.x;
        reviveY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage) //데미지를 입는 함수
    {
        health -= damage;
        //UnityEngine.Debug.Log(health);
        animator.SetTrigger("trigger_getAttacked");
    }

    public void GetStunned(float time) //스턴당하는 함수
    {
        animator.SetTrigger("trigger_getStunned");
    }

    public void Revive()
    {
        animator.SetBool("bool_death", false);
        transform.position = new Vector3(reviveX, reviveY, 0f);
    }
}
