using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Target _targetArrow;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    private string _animationDead = "Dying";

    public Target TargetArrow => _targetArrow;
  [field:SerializeField]  public int Money { get; private set; }
    public bool IsDead { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (IsDead == false)
            Shoot();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            _animator.Play(_animationDead);
            IsDead = true;
            Destroy(gameObject, 3.5f);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot();
        }
    }

}
