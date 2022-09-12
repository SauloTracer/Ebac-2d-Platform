using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D (Collision2D other) {
        // Debug.Log("Hit " + other.gameObject.name);
        var health = other.gameObject.GetComponent<Health>();
        health?.TakeDamage(damage);
    }
}
