using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_door : MonoBehaviour
{
    public int wallRole = 0; //통과할 수 없는 벽 취급이므로 설정

    void Start()
    {
        gameObject.tag = "wall";
    }

    void Update()
    {
        
    }
}
