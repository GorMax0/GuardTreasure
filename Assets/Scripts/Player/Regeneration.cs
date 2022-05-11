using System;

[Serializable]
public class Regeneration : Parameter
{
    public override string ToString()
    {
        return $"Восстанавлиет по {Value} ОЗ в секунду. Увеличевает регенерацию ОЗ на {EnhancementMultiplir}.";
    }
}
