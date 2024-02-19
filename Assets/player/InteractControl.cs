using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{

    public GameObject collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collidedObject = collision.gameObject;
        Debug.Log(collidedObject.name);
        return;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collidedObject = null;
        return;
    }

    public void Interact()
    {
        if (collidedObject == null) return;

        if (collidedObject.name == "SaveA")
        {

        }

        if (collidedObject.name == "SaveB")
        {

        }

        //if (collidedObject.name == )
    }
}
