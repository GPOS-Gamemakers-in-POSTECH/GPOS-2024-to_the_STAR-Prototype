using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollisionCheck : MonoBehaviour
{

    public InteractControl interactControl;
    // Start is called before the first frame update
    void Start()
    {
        interactControl = GetComponentInParent<InteractControl>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        interactControl.collidedObject = collision.gameObject;
        return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactControl.collidedObject = null;
        return;
    }

}
