using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_savePoint : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        gameObject.tag = "object";
        player = GameObject.FindWithTag("player");
    }

    void Update()
    {
        
    }

    public void interAct() //상호작용을 할 때 해당 변수를 호출하면 됨
    {
        player.GetComponent<scrt_player>().reviveX = transform.position.x;
        player.GetComponent<scrt_player>().reviveY = transform.position.y;
    }
}
