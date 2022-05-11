using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ParameterPanel : MonoBehaviour
{
    [SerializeField] private PlayerParameterUP _playerParameter;
    [SerializeField] private ParemeterView _template;
    [SerializeField] private ItemContainer _container;
    [SerializeField] private TMP_Text _countParameterPoint;

    private Player _player;
    private List<ParemeterView> _views = new List<ParemeterView>();

    private void OnEnable()
    {
        _playerParameter.ParameterPointChanged += OnParameterPointChanged;
        OnParameterPointChanged();
    }

    private void OnDisable()
    {
        _playerParameter.ParameterPointChanged -= OnParameterPointChanged;
    }

    private void Start()
    {
        _player = _playerParameter.GetComponent<Player>();
        AddItem(_player.MaxHealth);
        AddItem(_player.Regeneration);
        AddItem(_player.Armor);
       // OnParameterPointChanged();
    }

    private void AddItem(Parameter parameter)
    {
        var view = Instantiate(_template, _container.transform);
        view.ParameterUPButtonClick += OnParameterUPButtonClick;
        view.Renger(parameter);
        _views.Add(view);
    }

    private void TryChangeInteractableButton()
    {
        bool canEnableButton = _playerParameter.ParameterPoint > 0;

        foreach (var view in _views)
        {
            view.ChangeInteractableButton(canEnableButton);
        }
    }

    private void OnParameterPointChanged()
    {
        TryChangeInteractableButton();
    }

    private void OnParameterUPButtonClick(Parameter parameter, ParemeterView view)
    {
        parameter.Enhance();
        _playerParameter.SpendParameterPoint();

        if (parameter.IsFullEnhancement)
            view.ParameterUPButtonClick -= OnParameterUPButtonClick;
    }
}
