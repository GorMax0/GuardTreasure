using TMPro;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TMP_Text _numberWave;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnValueChange;
        _spawner.NextWaveEnabled += SetTextNumberWave;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnValueChange;
        _spawner.NextWaveEnabled -= SetTextNumberWave;
    }

    private void SetTextNumberWave(int numberWave)
    {
        _numberWave.text = $"Волна № {numberWave}";
    }
}
