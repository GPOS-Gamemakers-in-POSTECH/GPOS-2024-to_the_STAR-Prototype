using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameGunController : MonoBehaviour
{
    // pointing vector
    private float angle;
    private Vector2 target, mouse;

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
    }
}
