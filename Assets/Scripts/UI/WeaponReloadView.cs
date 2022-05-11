using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReloadView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _reloadView;

    private Weapon _weapon;
    private float _normalize;

    private void OnEnable()
    {
        _player.WeaponChanged += OnWeaponChanged;
    }

    private void OnDisable()
    {
        _player.WeaponChanged -= OnWeaponChanged;
    }

    private void Update()
    {
        _normalize = _weapon.CurrentDelay / _weapon.CurrentDelay;

        if (_weapon.NeedReload)
        {
            _reloadView.fillAmount = 0;
            return;
        }

        if (_weapon.CurrentDelay > 0)
            _reloadView.fillAmount = Mathf.MoveTowards(_normalize, 0, _weapon.CurrentDelay / _weapon.ReloadDelay);

    }

    private void OnWeaponChanged(Weapon weapon)
    {
        _weapon = weapon;

        if (_weapon.CurrentDelay <= 0)
            _reloadView.fillAmount = _weapon.ReloadDelay / _weapon.ReloadDelay;
        else
            _reloadView.fillAmount = _weapon.CurrentDelay / _weapon.ReloadDelay;
    }
}
