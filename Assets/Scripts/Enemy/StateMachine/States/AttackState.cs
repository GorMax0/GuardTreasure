using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State, IBuff
{
    [SerializeField] private int _baseDamage;
    [SerializeField] private float _delay;

    private int _damage;
    private float _lastAttackTime;
    private Animator _animator;
    private string _animationAttack = "Attacking";
    private Coroutine _attackBuff;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _damage = _baseDamage;
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    public void StartBuff(int multiple, float actionTime)
    {
        if (_attackBuff != null)
            return;
        else
            _attackBuff = StartCoroutine(AttackBuff(multiple, actionTime));
    }

    private void Attack(Player target)
    {
        _animator.Play(_animationAttack);
        target.ApplyDamage(_damage);
    }

    private IEnumerator AttackBuff(int multiple, float actionTime)
    {
        _damage *= multiple;

        while (actionTime > 0)
        {
            yield return null;
            actionTime -= Time.deltaTime;
        }

        _damage = _baseDamage;
        _attackBuff = null;
    }
}
