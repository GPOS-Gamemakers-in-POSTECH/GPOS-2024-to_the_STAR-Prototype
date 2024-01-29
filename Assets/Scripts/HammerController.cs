using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    private Animator anim;
    private float baseDamage = 10.0f;
    private float chargeDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            chargeDamage += Time.deltaTime * 30;
            anim.SetBool("isAttack", false);
            anim.SetBool("isCharge", true);
            Debug.Log("Charge Damage: " + chargeDamage);

            if (chargeDamage >= 60)
            {
                anim.SetBool("isFullCharge", true);
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (chargeDamage >= 60)
            {
                anim.SetBool("isAttack", true);
                Debug.Log("Damage: " + (baseDamage + chargeDamage));
            }
            
            anim.SetBool("isCharge", false);
            anim.SetBool("isFullCharge", false);
            // anim.SetBool("isAttack", false);

            chargeDamage = 0;
        }   
    }
}
