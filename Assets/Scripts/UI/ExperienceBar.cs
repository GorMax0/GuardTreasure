using TMPro;
using UnityEngine;

public class ExperienceBar : Bar
{
    [SerializeField] private PlayerParameterUP _playerParameter;
    [SerializeField] private TMP_Text _levelPlayer;

    private void OnEnable()
    {
        _playerParameter.ExperienceChanged += OnValueChange;
        _playerParameter.LevelIncreased += SetTextLevelPlayer;
    }

    private void OnDisable()
    {
        _playerParameter.ExperienceChanged -= OnValueChange;
        _playerParameter.LevelIncreased -= SetTextLevelPlayer;
    }

    private void SetTextLevelPlayer(int level)
    {
        _levelPlayer.text = $"Уровень: {level}";
    }
}
