using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GuideControl : MonoBehaviour {

    Animator animator;
    public bool facingRight = true;

    private int waitTime;

    private int runTime;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        waitTime = 3;
        facingRight = true;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void WalkingRight()
    {
        runTime = 1;
        if (!facingRight)
        {
            Flip();
        }
        if (runTime == 1)
        { 
            facingRight = true;
            StartCoroutine(Move(waitTime));
            runTime++;
        }
    }

    public void WalkingLeft()
    {
        runTime = 1;
        if (facingRight)
        {
            Flip();
        }
        if (runTime == 1)
        {
            facingRight = false;
            StartCoroutine(Move(waitTime));
            runTime++;
        }
    }
    public void LayDown()
    {
        runTime = 1;
        if (!facingRight)
        {
            Flip();
        }
        if (runTime == 1)
        {
            facingRight = true;
            StartCoroutine(GetDown());
            runTime++;
        }
    }
    public void CrawlRight()
    {
        runTime = 1;
        if (!facingRight)
        {
            Flip();
        }
        if (runTime == 1)
        {
            facingRight = true;
            StartCoroutine(Crawl(5));
            runTime++;
        }
    }
    public void CrawlLeft()
    {
        runTime = 1;
        if(facingRight)
        {
            Flip();
        }
        if (runTime == 1)
        {
            facingRight = false;
            StartCoroutine(Crawl(5));
            runTime++;
        }
    }
    public void StandUp()
    {
        runTime = 1;

        if (!facingRight)
        {
            Flip();
        }
        if(runTime == 1)
        {
            facingRight = true;
            StartCoroutine(GetUp());
            runTime++;
        }
        
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;

    }
    IEnumerator Move(int wait)
    {
        animator.SetBool("Walk", true);
        yield return new WaitForSeconds(wait);
        animator.SetBool("Walk", false);
        animator.SetBool("EndWalk", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("EndWalk", false);
    }
    IEnumerator GetDown()
    {
        animator.SetBool("LayDown", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("LayDown", false);
        animator.SetBool("StandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("StandUp", false);
        animator.SetBool("EndStandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("EndStandUp", false);
    }
    IEnumerator Crawl(int wait)
    {
        animator.SetBool("LayDown", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("LayDown", false);
        animator.SetBool("Crawl", true);
        yield return new WaitForSeconds(wait);
        animator.SetBool("Crawl", false);
        animator.SetBool("StandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("StandUp", false);
        animator.SetBool("EndStandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("EndStandUp", false);

    }
    IEnumerator GetUp()
    {
        animator.SetBool("LayDown", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("LayDown", false);
        animator.SetBool("StandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("StandUp", false);
        animator.SetBool("EndStandUp", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("EndStandUp", false);
    }
    public void BackToMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
