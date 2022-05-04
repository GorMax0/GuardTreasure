using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DieTransition : Transition
{
    private Enemy _current;

    private void Awake()
    {
        _current = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _current.Died += Die;
    }

    private void OnDisable()
    {
        _current.Died -= Die;
    }

    private void Die(Enemy current)
    {
        NeedTransit = true;
    }
}
