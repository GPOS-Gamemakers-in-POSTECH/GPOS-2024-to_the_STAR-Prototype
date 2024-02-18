using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;

    
    void Update()
    {
        // sub menu script

        if(Input.GetButtonDown("Cancel"))
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else 
                menuSet.SetActive(true);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
