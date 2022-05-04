using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private string _animationIdle = "Idle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_animationIdle);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
