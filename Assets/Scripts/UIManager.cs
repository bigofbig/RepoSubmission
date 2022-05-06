using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

 public void StarGame()
    {
        SceneManager.LoadScene(1);
    }
public void Exit()
    {
        Application.Quit();
        print("Exited");
    }

}
