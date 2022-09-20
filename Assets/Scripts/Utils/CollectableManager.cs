using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;

public class CollectableManager : Singleton<CollectableManager>
{
    public int coins = 0;

    public new void Awake() {
        base.Awake();
        Reset();
    }

    private void Reset() {
        coins = 0;
    }

    public void AddCoins(int amount = 1) {
        coins += amount;
    }
}