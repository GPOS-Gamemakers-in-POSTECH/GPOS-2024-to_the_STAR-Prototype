using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // player data
    private float moveSpeed = 5f;

    // components
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // child
    private GameObject hammer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "player";
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        hammer = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (moveDirection > 0)
        {
            sr.flipX = false;
            hammer.transform.localPosition = new Vector3(0.5f, 0, 0);
            hammer.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection < 0)
        {
            sr.flipX = true;
            hammer.transform.localPosition = new Vector3(-0.5f, 0, 0);
            hammer.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
