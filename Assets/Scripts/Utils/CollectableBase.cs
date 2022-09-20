using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    private const string target = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag(target)) {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Collect");
        OnCollect();
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() {}
}
