using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private int _maxEnemyCount;

    private int _enemyCount;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy());
    }

    private IEnumerator SpawnRandomEnemy()
    {
        var secondsBetweenSpawn = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            if (_enemyCount < _maxEnemyCount)
            {
                Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], GetRandomPointInSphere(_spawnRadius), Quaternion.identity);
                _enemyCount++;

                Vector3 lookDirection = _player.transform.position - newEnemy.transform.position;
                newEnemy.transform.rotation = Quaternion.LookRotation(lookDirection);
                newEnemy.Died += OnEnemyDied;
            }

            yield return secondsBetweenSpawn;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;              // отписка при смерти врага

        _player.AddScore();
        _enemyCount--;
    }

    private Vector3 GetRandomPointInSphere(float radius)
    {
        return Random.insideUnitSphere * radius;    // + Vector3 для смещения центра сферы
    }
}
