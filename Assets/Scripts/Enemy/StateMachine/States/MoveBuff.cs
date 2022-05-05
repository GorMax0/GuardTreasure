public class MoveBuff : BuffState
{
    protected override State GetStateForBuff(Enemy enemy)
    {
        var stateForBuffs = enemy.GetComponents<State>();

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
