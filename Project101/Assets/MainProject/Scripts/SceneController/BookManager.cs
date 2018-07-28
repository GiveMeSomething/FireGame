using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookManager : MonoBehaviour {

    public Book book;
    public GameObject backButton;
    private Image leftNext;
    private Image rightNext;

    private void Start()
    {
        leftNext = book.LeftNext;
        rightNext = book.RightNext;

        backButton.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        leftNext = book.LeftNext;
        rightNext = book.RightNext;

        if (rightNext.sprite.name == "BlankPage")
        {
            backButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(false);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
