using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public int lifePoints = 10;
   public bool destroyOnDeath = false;
   public float delayDeath = 0.5f;

   public Action OnDeath;

   private int _currentLife;
   private bool _isDead;

   private void Awake() {
        Init();
   }
    public void Init() {
            _currentLife = lifePoints;
            _isDead = false;
    }

    public void TakeDamage(int damage) {
        _currentLife -= damage;
        if (_currentLife <= 0) {
            _isDead = true;
            Die();
        }
    }

    public void Die() {
        OnDeath?.Invoke();
        if (destroyOnDeath) {
            Destroy(gameObject, delayDeath);
        }
    }
}
