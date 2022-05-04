using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBuffTransition : Transition
{
    [SerializeField] private float _delayBetweenBuffs;

    private float _timeAfterBuff;

    private void OnEnable()
    {
        _timeAfterBuff = _delayBetweenBuffs;
    }

    void Update()
    {
        if (_timeAfterBuff <= 0)
        {
            NeedTransit = true;
            _timeAfterBuff = _delayBetweenBuffs;
        }

        _timeAfterBuff -= Time.deltaTime;
    }
}
