using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.25f;

    private Vector2 offset;

    public bool movable = true;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 playerPosition2D = new Vector2(player.position.x, this.transform.position.y);
        Vector2 position = playerPosition2D + offset;
        Vector2 smoothPosition = Vector2.Lerp(transform.position, position, smoothSpeed);

        transform.position = smoothPosition;
    }
}
