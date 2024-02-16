using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_lever : MonoBehaviour
{
    public int floorLoc = 0; //딛고 있는 바닥의 위치, 0: 바닥, 1: 왼쪽벽 2: 천장 3: 오른쪽벽
    public int leverCode = 0; //0: 뭔가를 없애는 레버  1: 뭔가를 만드는 레버
    public int remoteFloorLoc = 0; //없애거나 만들 오브젝트가 딛을 바닥의 위치
    public float obx; //해당 레버가 무엇을 만들거나 없앨지 해당되는 위치에 대한 좌표값
    public float oby;
    public GameObject whatObj; //뭘 없애고 만들지 지정

    SpriteRenderer spriteRenderer;
    Animator animator;

    GameObject relatedObj;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameObject.tag = "object";

        if (floorLoc != 0) { spriteRenderer.transform.localRotation = Quaternion.Euler(0f, 0f, (4 - floorLoc) * 90f); }

        if(leverCode == 0)
        {
            relatedObj = Instantiate(whatObj, new Vector3(obx, oby, 0f), Quaternion.Euler(0f, 0f, (4 - remoteFloorLoc) * 90f));
            animator.SetBool("bool_On", false);
        }
        else
        {
            animator.SetBool("bool_On", true);
        }
    }

    void Update()
    {
        
    }

    public void interAct() //상호작용을 할 때 해당 변수를 호출하면 됨
    {
        if (leverCode == 0) //제거
        {
            Destroy(relatedObj);
            leverCode = 1;
            animator.SetBool("bool_On", false);
        }
        else //생성
        {
            relatedObj = Instantiate(whatObj, new Vector3(obx, oby, 0f), Quaternion.Euler(0f, 0f, (4 - remoteFloorLoc) * 90f));
            leverCode = 0;
            animator.SetBool("bool_On", true);
        }
    }
}
