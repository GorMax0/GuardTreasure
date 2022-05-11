using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleEffect))]
public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private int _baseMultiple = 1;
    private Coroutine _changeMultiple;
    private ParticleEffect _particleEffect;

    protected int Multiple;

    protected Player Target { get; private set; }

    private void Start()
    {
        Multiple = _baseMultiple;
    }

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNext()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }

    public void StartChangeMultipe(int multiple, float actionTime, ParticleSystem effect)
    {
        if (_changeMultiple != null)
            return;
        else
            _changeMultiple = StartCoroutine(ChangeMultiple(multiple, actionTime, effect));
    }

    private IEnumerator ChangeMultiple(int multiple, float actionTime, ParticleSystem effect)
    {
        Multiple = multiple;
        CacheParticleEffect();
        _particleEffect.StartEffect(effect);

        while (actionTime > 0)
        {
            yield return null;
            actionTime -= Time.deltaTime;
        }

        Multiple = _baseMultiple;
        _particleEffect.StopEffect(effect);
        _changeMultiple = null;
    }

    private void CacheParticleEffect()
    {
        if (_particleEffect != null)
            return;

        _particleEffect = GetComponent<ParticleEffect>();
    }
}
