using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongsController : MonoBehaviour
{
    // pointing vector
    private float angle;
    private Vector2 target, mouse;
    private Vector2 hitLocation;

    // coroutine
    Coroutine runningCoroutine = null; 

    // state
    private bool isSleep = false;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "playerWeapon";
    }

    // Update is called once per frame
    void Update()
    {
        // rotate flamethrower
        target = transform.parent.position;
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);


        // move tongs head
        if (Input.GetMouseButton(0))
        {
            if (!isSleep && !isHit && Vector2.Distance(transform.GetChild(0).position, transform.position) < 3f)
            {
                transform.GetChild(0).position = Vector2.MoveTowards(transform.GetChild(0).position, mouse, .1f);
            }
            else if (isHit)
            {
                transform.GetChild(0).position = hitLocation;
            }
        }

        // return tongs head
        if (Input.GetMouseButtonUp(0))
        {
            transform.GetChild(0).localPosition = new Vector3(0.3f, 0, 0);
            StartCoroutine(Cooltime());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isHit = true;
            hitLocation = transform.GetChild(0).position;
            Debug.Log("Enemy Hit by Tongs (detected at parent)");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isHit = false;
        }
    }

    IEnumerator Cooltime()
    {
        isSleep = true;
        yield return new WaitForSeconds(1);
        isSleep = false;
    }
}
