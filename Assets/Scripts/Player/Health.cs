using System;
using UnityEngine.Events;

[Serializable]
public class Health : Parameter
{
    public UnityAction<int> MaxHealthIncreased;

    public override string ToString()
    {
        return $"Текушее значение {Value} ОЗ. Увеличивает максимальное количество ОЗ на {EnhancementMultiplir}.";
    }
}
