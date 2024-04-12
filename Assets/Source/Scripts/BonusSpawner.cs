using System;
using Source.Scripts.GameEntities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class BonusSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyGroup _enemyGroup;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Bonus _bonus;
        [SerializeField] private float _spawnChance;

        private void Awake()
        {
            _enemySpawner.OnSpawn += SetupBonusSpawn;
        }

        private void SetupBonusSpawn(Enemy enemy)
        {
            enemy.OnDie += _ =>
            {
                float chance = Random.Range(0f, 1f);
                if (chance >= _spawnChance)
                {
                    Bonus bonus = Instantiate(_bonus, enemy.transform.position, Quaternion.identity);
                    bonus.Setup(_enemyGroup);
                }
            };
        }
    }
}