using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        applyGravity(PlayerState.gravitentialForce);

        return;
    }

    public void MoveLeft(float moveSpeed)
    {
        Vector2 leftVector = new Vector2(PlayerState.gravityVector.y, -PlayerState.gravityVector.x);
        transform.Translate(leftVector);

        return;
    }

    public void MoveRight(float moveSpeed)
    {
        Vector2 rightVector = new Vector2(-PlayerState.gravityVector.y, -PlayerState.gravityVector.x);
        transform.Translate(rightVector);

        return;
    }

    void applyGravity(float gravitentialForce)
    {
        rb.AddForce(PlayerState.gravityVector * gravitentialForce);

        return;
    }


}
