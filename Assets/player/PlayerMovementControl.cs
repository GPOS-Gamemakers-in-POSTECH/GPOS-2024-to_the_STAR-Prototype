using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //ApplyGravity(PlayerState.gravitentialForce);

        return;
    }

    public void MoveLeft(float moveSpeed)
    {
        Vector2 leftVector = new Vector2(PlayerState.gravityVector.y, -PlayerState.gravityVector.x);
        //transform.Translate(leftVector * Time.deltaTime);
        rb.AddForce(leftVector* 100);
        return;
    }

    public void MoveRight(float moveSpeed)
    {
        Vector2 rightVector = new Vector2(-PlayerState.gravityVector.y, -PlayerState.gravityVector.x);
        //transform.Translate(rightVector * Time.deltaTime);
        rb.AddForce(rightVector * 100);
        return;
    }

    void ApplyGravity(float gravitentialForce)
    {
        rb.AddForce(PlayerState.gravityVector * gravitentialForce);
        //UnityEngine.Debug.Log(PlayerState.gravityVector);

        return;
    }


}
