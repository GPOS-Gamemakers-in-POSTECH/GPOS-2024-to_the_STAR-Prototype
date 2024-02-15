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
    }

    public void UpdateGravityVector()
    {
        if (PlayerState.gravitySourceVector == null) return;

        PlayerState.gravityVector = (PlayerState.gravitySourceVector - PlayerState.playerCoordinateVector).normalized;

    }
}
