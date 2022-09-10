using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rigidBody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        }
    }
}
