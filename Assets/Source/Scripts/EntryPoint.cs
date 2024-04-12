using System;
using Source.Scripts;
using Source.Scripts.GameEntities;
using Unity.Mathematics;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private EndLine _endLine;
    
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        _enemySpawner.StartSpawn();
        Instantiate(_player, _playerSpawnPoint.position, quaternion.identity).OnPlayerDie += EndGame;
        _endLine.OnEndLineReached += EndGame;
    }

    private void EndGame()
    {
        _enemySpawner.StopSpawn();
        Debug.Log("GameOver");
    }
}