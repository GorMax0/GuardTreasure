public class AttackBuff : BuffState
{
    protected override IBuff GetStateForBuff(Enemy enemy)
    {
        var stateForBuffs = enemy.GetComponents<IBuff>();

        foreach (var state in stateForBuffs)
        {
            if (state as AttackState)
            {
                return state;
            }
        }

        return null;
    }
}
