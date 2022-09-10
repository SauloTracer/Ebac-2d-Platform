using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonGridManager : MonoBehaviour
{

    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = 0.5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;

    void OnEnable()
    {
        HideButtons();
        ShowButtons();
    }

    private void HideButtons() {
        foreach (var b in buttons) {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons() {
        for (int i = 0; i < buttons.Count; i++) {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(delay * i).SetEase(ease);
        }
    }
}
