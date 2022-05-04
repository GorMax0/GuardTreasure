using System.Collections.Generic;
using UnityEngine;

public abstract class BuffState : State
{
    [SerializeField] private int _multipeValue;
    [SerializeField] private float _actionTime;
    [SerializeField] private int _amountEnemysForBuff;

    private List<IBuff> _targetEnemys = new List<IBuff>();

    private void OnEnable()
    {
        AppleyBuff();
    }

    protected abstract IBuff GetStateForBuff(Enemy enemy);

    private void AppleyBuff()
    {
        SetTargetEnemys();

        for (int i = 0; i < _targetEnemys.Count;)
        {
            _targetEnemys[i].StartBuff(_multipeValue, _actionTime);
            _targetEnemys.RemoveAt(i);
        }
    }

    private void SetTargetEnemys()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.right);

        for (int i = 0; i < hits.Length; i++)
        {
            if (_targetEnemys.Count == _amountEnemysForBuff)
            {
                return;
            }
            else
            {
                if (hits[i].collider.TryGetComponent(out Enemy enemy))
                {
                    var stateForBuff = GetStateForBuff(enemy);

                    _targetEnemys.Add(stateForBuff);
                }
            }
        }
    }
}

