using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_enemyAttack : MonoBehaviour
{
    public float attack;
    public float bulletSpeed;
    public int enemyCode;

    Vector3 playerLoc;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
        gameObject.tag = "enemyWeapon";
        playerLoc = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) //물리충돌을 사용하지 않는 충돌 사용
    {
        if (col.tag == "player")
        {
            col.gameObject.GetComponent<scrt_player>().Damage(attack);
        }
    }
}
