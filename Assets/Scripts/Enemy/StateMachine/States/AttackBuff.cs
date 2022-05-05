public class AttackBuff : BuffState
{
    protected override State GetStateForBuff(Enemy enemy)
    {
        var stateForBuffs = enemy.GetComponents<State>();

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
