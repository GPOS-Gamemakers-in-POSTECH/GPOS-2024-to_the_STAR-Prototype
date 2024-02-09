using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrt_enemyAttack : MonoBehaviour
{
    public float attack = 0;
    public float bulletSpeed = 0;
    public int enemyCode = 0; //더스트팬: 0  드론: 1  골렘: 2
    public int lifeDuration = -1;

    int lifeTime = 0;
    float distance;

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
        lifeTime++;
        if (lifeTime == lifeDuration)
        {
            Destroy(gameObject);
        }

        if (enemyCode == 0)
        {

        }
        else if (enemyCode == 1)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, playerLoc, bulletSpeed);
        }
    }

    private void OnTriggerEnter(Collider col) //물리충돌을 사용하지 않는 충돌 사용
    {
        if (col.tag == "player")
        {
            col.gameObject.GetComponent<scrt_player>().Damage(attack);
        }
    }
}
