public class MoveBuff : BuffState
{
    protected override IBuff GetStateForBuff(Enemy enemy)
    {
        var stateForBuffs = enemy.GetComponents<IBuff>();

        foreach (var state in stateForBuffs)
        {
            if (state as MoveState)
            {
                return state;
            }
        }

        return null;
    }
}
