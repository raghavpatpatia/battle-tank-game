using UnityEngine;

public class IdleState : EnemyTankState
{
    private float idleDuration = 3.0f;
    private float idleTimer;
    public IdleState(EnemyTankController enemyTankController) : base(enemyTankController) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        state = EnemyStates.Idle;
        idleTimer = idleDuration;
    }
    public override void Tick() 
    {
        base.Tick();
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            ChangingStates();
        }
    }

    private void ChangingStates()
    {
        if (playerDistance <= enemyTankController.playerChaseDistance)
        {
            enemyTankController.ChangeState(EnemyStates.Chase);
            return;
        }
        else
        {
            enemyTankController.ChangeState(EnemyStates.Patrol);
            return;
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}