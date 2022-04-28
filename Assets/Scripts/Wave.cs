using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    [SerializeField] private Enemy[] _enemy;
    [SerializeField] private float _delay;

    public float Delay => _delay;

    public Enemy GetNextEnemy(int index)
    {
        return _enemy[index];
    }

    public int GetLengthWave()
    {
        return _enemy.Length;
    }
}
