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
    public int Money { get; private set; }
    public bool IsDead { get; private set; }

    public event UnityAction<int, int> HealthChange;


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
        HealthChange?.Invoke(_currentHealth, _maxHealth);

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
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot();
        }
    }

}
