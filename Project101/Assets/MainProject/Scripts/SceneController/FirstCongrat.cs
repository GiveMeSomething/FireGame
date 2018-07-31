using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstCongrat : MonoBehaviour
{
    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeSceneNext()
    {
        SceneManager.LoadScene("Main2");
    }
}
