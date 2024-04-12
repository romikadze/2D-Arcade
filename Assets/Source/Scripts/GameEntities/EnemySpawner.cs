using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts.GameEntities
{
    public class EnemySpawner : MonoBehaviour
    {
        public Action<Enemy> OnSpawn;

        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _spawnRate;
        [SerializeField] private float _spawnYPosition;
        [SerializeField] private float _maxSpawnXPosition;

        private Coroutine _spawnTick;

        private Vector2 GetRandomSpawnPosition()
        {
            return new Vector2(Random.Range(-_maxSpawnXPosition, _maxSpawnXPosition), _spawnYPosition);
        }

        private IEnumerator SpawnTick()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                Enemy enemy = Instantiate(_enemy, GetRandomSpawnPosition(), Quaternion.identity);
                OnSpawn?.Invoke(enemy);
            }
        }

        public void StartSpawn()
        {
            if (_spawnTick != null)
                StopSpawn();

            _spawnTick = StartCoroutine(SpawnTick());
        }

        public void StopSpawn()
        {
            if (_spawnTick != null)
                StopCoroutine(_spawnTick);
        }
    }
}