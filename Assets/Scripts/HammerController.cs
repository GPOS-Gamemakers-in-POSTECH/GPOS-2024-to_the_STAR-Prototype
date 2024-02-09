using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    // hammer animation
    private Animator anim;

    // components
    private CircleCollider2D weaponCollider;

    // hammer data
    private float baseDamage = 25.0f;
    private float maxDamage = 100.0f;
    private float chargeDamage = 0;

    // state
    private bool isAttackable = true;

    // coroutine
    Coroutine runningCoroutine = null;

    void Start()
    {
        // gameObject.tag = "weapon";

        anim = GetComponent<Animator>();
        weaponCollider = GetComponent<CircleCollider2D>();
        weaponCollider.enabled = false;
    }

    // for physics
    void FixedUpdate()
    {
    }

    void Update()
    {        
        // Press the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            if (isAttackable)
                runningCoroutine = StartCoroutine(Charge());
        }
        
        // Release the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            if (runningCoroutine != null)
            {
                StopCoroutine(runningCoroutine);
            }

            if (isAttackable)
            {
                StartCoroutine(Attack());
                chargeDamage = 0;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision: " + other.gameObject.tag);
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("Enemy Hit");
        }
    }

    IEnumerator Charge()
    {
        anim.SetTrigger("triggerCharge");
        while (true)
        {
            chargeDamage += 2;
            
            if (chargeDamage >= 100)
            {
                anim.SetTrigger("triggerFullCharge");
                yield break;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
    
    IEnumerator Attack()
    {
        // attack
        isAttackable = false;
        Debug.Log("Damage: " + (baseDamage + chargeDamage));
        anim.SetTrigger("triggerAttack");
        weaponCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        weaponCollider.enabled = false;

        // cooldown
        anim.SetTrigger("triggerSleep");
        yield return new WaitForSeconds(3.0f);
        anim.SetTrigger("triggerIdle");
        isAttackable = true;
    }
}
