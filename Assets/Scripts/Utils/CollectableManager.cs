using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;
using TMPro;
using System;

public class CollectableManager : Singleton<CollectableManager>
{
    public int coins = 0;
    public Action CollectedCoin;

    public new void Awake() {
        base.Awake();
        Reset();
    }

    private void Reset() {
        coins = 0;
    }

    public void AddCoins(int amount = 1) {
        coins += amount;
        CollectedCoin?.Invoke();
    }
}