using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Health _maxHealth;
    [SerializeField] private Regeneration _regeneration;
    [SerializeField] private Armor _armor;
    [SerializeField] private List<Weapon> _allWeapons;
    [SerializeField] private List<Weapon> _unlockWeapons;
    [SerializeField] private Target _targetArrow;

    private int _currentHealth;
    private int _currentWeaponNumber = 0;
    private Weapon _currentWeapon;
    private Animator _animator;
    private string _animationDead = "Dying";

    public Health MaxHealth => _maxHealth;
    public Regeneration Regeneration => _regeneration;
    public Armor Armor => _armor;
    public Target TargetArrow => _targetArrow;
    public int Money { get; private set; }
    public bool IsDead { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction MoneyChanged;
    public event UnityAction<Weapon> WeaponChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentWeapon = _unlockWeapons[_currentWeaponNumber];
        WeaponChanged?.Invoke(_currentWeapon);
        _currentHealth = _maxHealth.Value;
        StartCoroutine(RegenerateHealth());
    }

    public void ApplyDamage(int damage)
    {
        int fullPercentage = 100;
        int armorRatio = damage / fullPercentage * _armor.Value;

        _currentHealth -= damage - armorRatio;
        HealthChanged?.Invoke(_currentHealth, _maxHealth.Value);

        if (_currentHealth <= 0)
        {
            _animator.Play(_animationDead);
            IsDead = true;
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke();
    }

    public void BuyWeapon(Weapon purchasedWeapon)
    {
        foreach (var weapon in _allWeapons)
        {
            if (weapon == purchasedWeapon)
            {
                Money -= purchasedWeapon.Price;
                MoneyChanged?.Invoke();
                _unlockWeapons.Add(weapon);
                NextWeapon();
                return;
            }
        }
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _unlockWeapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_unlockWeapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _unlockWeapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_unlockWeapons[_currentWeaponNumber]);
    }

    public void Shoot()
    {
        if (IsDead == false)
        {
            _currentWeapon.Shoot();
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = weapon;
        _currentWeapon.gameObject.SetActive(true);
        WeaponChanged?.Invoke(_currentWeapon);
    }

    private IEnumerator RegenerateHealth()
    {
        WaitForSeconds delayRegeneration = new WaitForSeconds(1f);

        while (IsDead == false)
        {
            if (_currentHealth < _maxHealth.Value)
            {
                _currentHealth = Mathf.Clamp(_currentHealth + _regeneration.Value, _currentHealth, _maxHealth.Value);
                HealthChanged?.Invoke(_currentHealth, _maxHealth.Value);
            }

            yield return delayRegeneration;
        }
    }
}
