using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject targetPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = new Vector3(targetPlayer.transform.position.x, this.transform.position.y, 0.0f);
        this.transform.position = playerPos;
	}
}
