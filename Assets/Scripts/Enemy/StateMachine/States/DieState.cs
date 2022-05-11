using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DieState : State
{
    private Animator _animator;
    private string _animationDying = "Dying";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(_animationDying);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
