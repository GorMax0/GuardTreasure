using UnityEngine;
using UnityEngine.Events;

public class PlayerParameterUP : MonoBehaviour
{
    private int _level = 1;
    private int _parameterPoint;
    private int _needExperience = 10;
    private int _experience;
    private float _experienceMultiplier = 1.28f;

    public event UnityAction<int, int> ExperienceChanged;
    public event UnityAction<int> LevelIncreased;
    public event UnityAction ParameterPointChanged;

    public int ParameterPoint => _parameterPoint;

    public void AddExperience(int experience)
    {
        _experience += experience;

        if (_experience >= _needExperience)
        {
            LevelUp();
        }

        ExperienceChanged?.Invoke(_experience, _needExperience);
    }

    public void SpendParameterPoint()
    {
        if (_parameterPoint > 0)
        {
            _parameterPoint--;
            ParameterPointChanged?.Invoke();
        }
    }

    private void LevelUp()
    {
        _experience -= _needExperience;
        _level++;
        _parameterPoint++;
        ParameterPointChanged?.Invoke();
        _needExperience = Mathf.CeilToInt(_needExperience * _experienceMultiplier);
        LevelIncreased?.Invoke(_level);
    }
}
