using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    private int spinSpeed = 90;

    public void Update() {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + spinSpeed * Time.deltaTime, 0);
    }

    protected override void OnCollect() {
        base.OnCollect();
        CollectableManager.instance.AddCoins();
    }
}
