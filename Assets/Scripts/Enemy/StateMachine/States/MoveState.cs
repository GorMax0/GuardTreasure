using System.Collections;
using UnityEngine;

public class MoveState : State, IBuff
{
    [SerializeField] private float _baseSpeed;

    private float _speed;
    private Coroutine _speedBuff;

    private void Start()
    {
        _speed = _baseSpeed;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.TargetArrow.transform.position, _speed * Time.deltaTime);
    }

    public void StartBuff(int multiple, float actionTime)
    {
        if (_speedBuff != null)
            return;
        else
            _speedBuff = StartCoroutine(SpeedBuff(multiple, actionTime));
    }

    private IEnumerator SpeedBuff(int multiple, float actionTime)
    {
        _speed *= multiple;

        while (actionTime > 0)
        {
            yield return null;
            actionTime -= Time.deltaTime;
        }

        _speed = _baseSpeed;
        _speedBuff = null;
    }
}