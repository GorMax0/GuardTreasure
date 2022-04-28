using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Spawner _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private int _lengthCurrentWave;
    private float _timeAfterLastSpawn;
    private int _indexEnemySpawned = 0;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _indexEnemySpawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_indexEnemySpawned, _lengthCurrentWave);
        }

        if (_indexEnemySpawned >= _lengthCurrentWave)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _indexEnemySpawned = 0;
        EnemyCountChanged?.Invoke(_indexEnemySpawned, _lengthCurrentWave);
    }

    private void InstantiateEnemy()
    {
        Enemy currentEnemy = _currentWave.GetNextEnemy(_indexEnemySpawned);

        Enemy enemy = Instantiate(currentEnemy, _spawnPoint.transform.position, _spawnPoint.transform.rotation, _spawnPoint.transform);
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        _lengthCurrentWave = _currentWave.GetLengthWave();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;

        _player.AddMoney(enemy.Reward);
    }
}