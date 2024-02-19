using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // player data
    private float health = 100.0f;
    private float moveSpeed = 3f;

    private float stunResistance = 1.0f;
    private float confusionResistance = 10.0f;

    // components
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // weapons
    private GameObject hammer;
    private GameObject flamethrower;
    private GameObject tongs;

    //weapon on/off
    public bool hammerOn = false;
    public bool tongsOn = false;
    public bool flamethrowerOn = false;

    Vector2 movement;
    bool wallCollide = false;
    double angle;

    void Start()
    {
        gameObject.tag = "player";

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // weapons
        hammer = transform.GetChild(0).gameObject;
        flamethrower = transform.GetChild(1).gameObject;
        tongs = transform.GetChild(2).gameObject;
    }

    Vector2 rotationMatrix(float x, float y)
    {
        return new Vector2((float)Math.Cos(angle) *x+-1*(float)Math.Sin(angle) *y,(float)Math.Sin(angle) *x+(float)Math.Cos(angle) *y);
    }

    void FixedUpdate()
    {
        angle = Quaternion.FromToRotation(Vector3.down, PlayerState.gravityVector).eulerAngles.z;
        // UnityEngine.Debug.Log(angle);
        angle = (double)((int)((angle +1)/2)*2)/ 180 * Math.PI;
        transform.rotation = Quaternion.Euler(0, 0, (float)(angle * 180 / Math.PI));

        float moveDirection = Input.GetAxisRaw("Horizontal");
        if (wallCollide)
        {
            movement = rotationMatrix(-1 * moveSpeed * moveDirection, 0);
        }
        else
        {
            movement = rotationMatrix(moveSpeed * moveDirection, 0);
        }
        rb.velocity = movement;
        //UnityEngine.Debug.Log(movement);

        if (moveDirection > 0)
        {
            sr.flipX = true;
            //hammer.transform.localPosition = new Vector3(0.5f, 0, 0);
            //hammer.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection < 0)
        {
            sr.flipX = false;
            //hammer.transform.localPosition = new Vector3(-0.5f, 0, 0);
            //hammer.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Update()
    {
        // select weapon
        if (Input.GetKeyDown(KeyCode.Alpha1) && hammerOn)
        {
            hammer.SetActive(true);
            flamethrower.SetActive(false);
            tongs.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && flamethrowerOn)
        {
            hammer.SetActive(false);
            flamethrower.SetActive(true);
            tongs.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && tongsOn)
        {
            hammer.SetActive(false);
            flamethrower.SetActive(false);
            tongs.SetActive(true);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall") //벽과 충돌
        {
            wallCollide = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall") //벽과 충돌
        {
            wallCollide = false;
        }
    }

}
