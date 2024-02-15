using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int playerHealth;
    public static int playerMoveSpeed;
    public static int playerAttributeDefense;
    public static int playerStunEffectDefense;
    public static int playerChaosEffectDefense;
    public static Vector2 gravityVector;
    public static Vector2 playerCoordinateVector;
    public static Vector2 gravitySourceVector;
    public static float gravitentialForce;
    void Awake()
    {
        playerHealth = 100;
        playerMoveSpeed = 5;
        playerAttributeDefense = 0;
        playerStunEffectDefense = 1;
        playerChaosEffectDefense = 10;
        gravityVector = Vector2.down;
        gravitentialForce = 10.0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
