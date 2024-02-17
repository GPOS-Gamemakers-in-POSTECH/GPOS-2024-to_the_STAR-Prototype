using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneChange()
    {
        SceneManager.LoadScene("Map");
    }
    public void ExitGame()
    {
        Application.Quit(); // 어플리케이션 종료
    }
}
