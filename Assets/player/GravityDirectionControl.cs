using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDirectionControl : MonoBehaviour
{
    
    void Start()
    {
        
    }


    void Update()
    {

    }

    void FixedUpdate()
    {
        UpdateGravityVector();
        Debug.Log(PlayerState.gravityVector);
    }

    public void UpdateGravityVector()
    {
        if (PlayerState.gravitySourceVector.x == 0 && PlayerState.gravitySourceVector.y == 0) return;



        PlayerState.gravityVector = PlayerState.gravitySourceDirection * (PlayerState.gravitySourceVector - PlayerState.playerCoordinateVector).normalized;

    }
}
