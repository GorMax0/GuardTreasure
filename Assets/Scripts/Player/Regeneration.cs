using System;

[Serializable]
public class Regeneration : Parameter
{
    public override string ToString()
    {
        return $"������������� �� {Value} �� � �������. ����������� ����������� �� �� {EnhancementMultiplir}.";
    }
}
