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
    public Text guideText;

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

        if(book.currentPage != 0)
        {
            guideText.gameObject.SetActive(false);
        }
        else
        {
            guideText.gameObject.SetActive(true);
        }

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
