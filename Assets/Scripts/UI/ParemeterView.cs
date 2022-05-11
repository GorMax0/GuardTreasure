using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ParemeterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _upButton;

    private Parameter _parameter;

    public event UnityAction<Parameter, ParemeterView> ParameterUPButtonClick;

    private void OnEnable()
    {

        _upButton.onClick.AddListener(OnButtonClick);
        _upButton.onClick.AddListener(TryLockParameter);
    }

    private void OnDisable()
    {
        _upButton.onClick.RemoveListener(OnButtonClick);
        _upButton.onClick.RemoveListener(TryLockParameter);
    }

    public void Renger(Parameter parameter)
    {
        _parameter = parameter;
        _label.text = parameter.Label;
        _description.text = parameter.ToString();
        _icon.sprite = parameter.Icon;
        _icon.SetNativeSize();
    }

    public void ChangeInteractableButton(bool stateIntractable)
    {
            _upButton.interactable = stateIntractable;
    }

    private void TryLockParameter()
    {
        if (_parameter.IsFullEnhancement)
            _upButton.interactable = false;
    }

    private void OnButtonClick()
    {        
        ParameterUPButtonClick?.Invoke(_parameter, this);
        _description.text = _parameter.ToString();
    }
}
