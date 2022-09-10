using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{

    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Player Animation")]
    public float duration = 0.5f;
    public float delay = 0.1f;
    public Ease ease = Ease.OutBack;

    [Header("Enemies")]
    public List<GameObject> enemies;
    
    [Header("Reference")]
    public Transform playerSpawnPoint;

    private GameObject _player;

    void Awake() {
        Init();
    }

    public void Init() {
        SpawnPlayer();
    }

    private void SpawnPlayer() {
        _player = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        _player.transform.DOScale(0, duration).SetEase(ease).From();
    }
    
}
