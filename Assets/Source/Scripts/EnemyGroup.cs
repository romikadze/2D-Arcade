using System;
using System.Collections.Generic;
using Source.Scripts.GameEntities;
using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(EnemySpawner))]
    public class EnemyGroup : MonoBehaviour
    {
        private EnemySpawner _enemySpawner;
        private List<Enemy> _enemies;

        private void Awake()
        {
            _enemies = new List<Enemy>();
            _enemySpawner = GetComponent<EnemySpawner>();
            _enemySpawner.OnSpawn += AddEnemy;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        private void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            enemy.OnDie += RemoveEnemy;
        }

        public void AffectGroupBonus(Bonus bonus)
        {
            foreach (var enemy in _enemies)
            {
                enemy.GetComponent<IBonusAffects>().StartAffect(bonus);
            }
        }
    }
}