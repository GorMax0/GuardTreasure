using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChange;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChange;
    }
}
