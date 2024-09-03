using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts {
    public class SpawnManager : MonoBehaviour {
        [SerializeField]
        private float spawnRange;

        [SerializeField] private GameObject enemyPrefab;
        
        [SerializeField] private GameObject powerUpPrefab;

        [SerializeField] private GameObject player;
        
        [SerializeField] private TextMeshProUGUI waveText;

        private int _wave = 1;

        private readonly List<GameObject> _enemiesAlive = new ();

        private void Start() {
            this.InvokeRepeating(nameof(InstantiatePowerUp), 4, 8);
            SpawnEnemyWave(_wave++);
        }

        private void Update() {
            if (_enemiesAlive.Count == 0) 
                SpawnEnemyWave(_wave++);
        }

        private void LateUpdate() {
            foreach (var enemy in _enemiesAlive.ToList().Where(enemy => enemy.IsDestroyed())) {
                _enemiesAlive.Remove(enemy);
            }
        }

        private void SpawnEnemyWave(int enemyCount) {
            for (var i = 0; i < enemyCount; i++) {
                InstantiateEnemy();
                waveText.text = $"Wave: {enemyCount}";
            }
        }

        private void InstantiateEnemy() {
            var enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            if (enemy.TryGetComponent(out EnemyController enemyController)) {
                enemyController.Init(player);
            }

            _enemiesAlive.Add(enemy);
        }
        
        private void InstantiatePowerUp() {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }

        private Vector3 GenerateSpawnPosition() {
            float randomPositionX = Random.Range(-spawnRange, spawnRange);
            float randomPositionZ = Random.Range(-spawnRange, spawnRange);
            return new Vector3(randomPositionX, 0, randomPositionZ);
        }
    }
}