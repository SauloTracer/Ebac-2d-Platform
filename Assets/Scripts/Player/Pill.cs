using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{

    public Color color = Color.red;

    // On trigger enter, change the color of the player to color
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = color;
            // Destroy(gameObject);
        }
    }
}
