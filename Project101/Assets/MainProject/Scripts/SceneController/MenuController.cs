﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeToGuide()
    {
        SceneManager.LoadScene("GuideScene");
    }
    public void ChangeToLearn()
    {
        SceneManager.LoadScene("BookScene");
    }
    public void ChangeToPractice()
    {

    }
    public void ChangeToPlay()
    {

    }

}
