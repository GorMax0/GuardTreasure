using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChange += OnValueChange;
    }

    private void OnDisable()
    {
        _player.HealthChange -= OnValueChange;
    }
}
