using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class LevelManager : MonoBehaviour
{

    [Header("Player")]
    public GameObject playerPrefab;
    public Cinemachine.CinemachineVirtualCamera playerCamera;
    public Canvas ui;

    [Header("Player Animation")]
    public float duration = 0.5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;

    [Header("Enemies")]
    public List<GameObject> enemies;
    
    [Header("Reference")]
    public Transform playerSpawnPoint;
    public TMP_Text coinsText;

    private GameObject _player;

    void Awake() {
        Init();
    }

    public void Init() {
        ui.gameObject.SetActive(true);
        SpawnPlayer();
        gameObject.GetComponent<CollectableManager>().CollectedCoin += UpdateCoinCounter;
    }

    private void SpawnPlayer() {
        _player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        _player.transform.DOScale(0, duration).SetEase(ease).From();
        playerCamera.Follow = _player.transform;
        playerCamera.LookAt = _player.transform;
    }

    private void UpdateCoinCounter() {
        coinsText.text = gameObject.GetComponent<CollectableManager>().coins.ToString();
    }
    
}
