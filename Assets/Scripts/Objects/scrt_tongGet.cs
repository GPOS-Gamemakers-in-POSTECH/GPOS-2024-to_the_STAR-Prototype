using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_tongGet : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<PlayerControl>().tongsOn = true;
            Destroy(gameObject);
        }
    }
}
