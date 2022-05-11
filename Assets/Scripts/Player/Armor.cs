using System;

[Serializable]
public class Armor : Parameter
{
    public override string ToString()
    {
        return $"Уменьшает получаемый урон на {Value}%. Увеличевает защиту на {EnhancementMultiplir}%.";
    }
}