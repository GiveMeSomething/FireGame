using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondCongrat : MonoBehaviour
{
    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
