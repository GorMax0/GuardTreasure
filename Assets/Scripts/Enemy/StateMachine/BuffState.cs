using System.Collections.Generic;
using UnityEngine;

public class BuffState : State
{
    [SerializeField] private State _stateForBuff;
    [SerializeField] private float _multipeValue;
    [SerializeField] private float _actionTime;    
    [SerializeField] private int _amountEnemysForBuff;

    private List<State> _targetEnemys;

    private void OnEnable()
    {
            AppleyBuff();
    }

    private void AppleyBuff()
    {
        SetTargetEnemys();

        foreach (var enemys in _targetEnemys)
        {
            enemys.StartBuff(_multipeValue, _actionTime);
        }

        _targetEnemys = null;
    }

    private void SetTargetEnemys()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, -transform.right);

        for (int i = 0; i < hit.Length; i++)
        {
            if (_targetEnemys.Count == _amountEnemysForBuff)
            {
                return;
            }
            else
            {
                if (hit[i].collider.TryGetComponent<State>(out State state) == _stateForBuff)
                {
                    _targetEnemys[i] = state;
                }
            }
        }
    }
}
