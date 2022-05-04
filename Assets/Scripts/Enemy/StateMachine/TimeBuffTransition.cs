using UnityEngine;

public class TimeBuffTransition : Transition
{
    [SerializeField] private float _delayBetweenBuffs;

    private float _timeAfterBuff;

    private void OnEnable()
    {
        _timeAfterBuff = _delayBetweenBuffs;
        NeedTransit = false;
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
