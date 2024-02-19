using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractControl : MonoBehaviour
{
    public GameObject collidedObject;

    // Start is called before the first frame update
    void Start()
    {
        collidedObject = null;    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (collidedObject == null) return;
        Debug.Log(collidedObject.name);

        if (collidedObject.name == "SaveA" || collidedObject.name == "SaveB")
        {
            collidedObject.GetComponent<scrt_savePoint>().interAct();
        }

        else
        {
            collidedObject.GetComponent<scrt_lever>().interAct();
        }

        
    }
}
