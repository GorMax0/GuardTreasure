using System;

[Serializable]
public class Armor : Parameter
{
    public override string ToString()
    {
        return $"��������� ���������� ���� �� {Value}%. ����������� ������ �� {EnhancementMultiplir}%.";
    }
}