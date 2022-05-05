using System.Collections.Generic;
using UnityEngine;

public abstract class BuffState : State
{
    [SerializeField] private int _multipeValue;
    [SerializeField] private float _actionTime;
    [SerializeField] private int _amountEnemysForBuff;
    [SerializeField] private ParticleSystem _actionEffectBuff;
    [SerializeField] private ParticleSystem _castEffectBuff;

    private List<State> _targetEnemys = new List<State>();

    private void OnEnable()
    {
        AppleyBuff();
    }

    protected abstract State GetStateForBuff(Enemy enemy);

    private void AppleyBuff()
    {
        SetTargetEnemys();

        for (int i = 0; i < _targetEnemys.Count;)
        {
            _targetEnemys[i].StartChangeMultipe(_multipeValue, _actionTime, _actionEffectBuff);
            _targetEnemys.RemoveAt(i);
        }

        if (_castEffectBuff != null)
        {
            _castEffectBuff.gameObject.SetActive(true);
            _castEffectBuff.Play();
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

