using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        GameScene();
    }

    private void GameScene()
    {
        if(Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

  
}
