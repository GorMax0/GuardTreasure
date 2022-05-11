using UnityEngine;

public abstract class Parameter
{
    [SerializeField] private int _value;
    [SerializeField] private int _enhancementMultiplir;
    [SerializeField] private string _label;    
    [SerializeField] private Sprite _icon;

    private int _maxCount = 50;
    private int _currentCount = 0;

    public bool IsFullEnhancement { get; private set; }
    public int Value => _value;
    public int EnhancementMultiplir => _enhancementMultiplir;
    public string Label => _label;
    public Sprite Icon => _icon;

    public virtual void Enhance()
    {
        _value += _enhancementMultiplir;
        _currentCount++;

        if (_currentCount == _maxCount)
            IsFullEnhancement = true;
    }
}
