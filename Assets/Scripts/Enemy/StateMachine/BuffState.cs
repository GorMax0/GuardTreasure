using System.Collections.Generic;
using UnityEngine;

public class BuffState : State
{
    [SerializeField] private State _stateForBuff;
    [SerializeField] private int _multipeValue;
    [SerializeField] private float _actionTime;
    [SerializeField] private int _amountEnemysForBuff;

    private List<State> _targetEnemys = new List<State>();

    private void OnEnable()
    {
        AppleyBuff();
    }

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
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, -transform.right);

        for (int i = 0; i < hit.Length; i++)
        {
            if (_targetEnemys.Count == _amountEnemysForBuff)
            {
                return;
            }
            else
            {
                if (hit[i].collider.TryGetComponent(out State state))
                {
                    _targetEnemys.Add(state);
                }
            }
        }
    }
}
