using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParameterPoint : MonoBehaviour
{

    [SerializeField] private TMP_Text _countParameterPoint;
    [SerializeField] private PlayerParameterUP _playerParameterUP;

    private void OnEnable()
    {
        _countParameterPoint.text = _playerParameterUP.ParameterPoint.ToString();
        _playerParameterUP.ParameterPointChanged += OnParameterPointChanged;
    }

    private void OnDisable()
    {
        _playerParameterUP.ParameterPointChanged -= OnParameterPointChanged;
    }

    private void OnParameterPointChanged()
    {
        _countParameterPoint.text = _playerParameterUP.ParameterPoint.ToString();
    }
}
