using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Spawner _spawnPoint;
    [SerializeField] private Player _player;

    private PlayerParameterUP _playerStats;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private int _lengthCurrentWave;
    private float _timeAfterLastSpawn;
    private int _indexEnemySpawned = 0;
    private int _countEnemyDied = 0;

    public event UnityAction AllEnemyDead;
    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction<int> NextWaveEnabled;

    private void Start()
    {
        _playerStats = _player.GetComponent<PlayerParameterUP>();
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            if (_countEnemyDied >= _lengthCurrentWave && _waves.Count > _currentWaveIndex + 1)
                AllEnemyDead?.Invoke();

            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _indexEnemySpawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_indexEnemySpawned >= _lengthCurrentWave)
            _currentWave = null;
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        _indexEnemySpawned = 0;
        _countEnemyDied = 0;
        EnemyCountChanged?.Invoke(_countEnemyDied, _lengthCurrentWave);
        NextWaveEnabled?.Invoke(_currentWaveIndex + 1);
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
        _playerStats.AddExperience(enemy.Experience);

        _countEnemyDied++;
        EnemyCountChanged?.Invoke(_countEnemyDied, _lengthCurrentWave);
    }
}