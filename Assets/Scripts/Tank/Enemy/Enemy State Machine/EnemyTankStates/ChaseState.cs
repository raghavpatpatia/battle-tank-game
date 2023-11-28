using UnityEngine;

public class ChaseState : EnemyTankState
{
    private float maxTime;
    private float timer;
    private float minDistance;
    private float stuckDuration;
    public ChaseState(EnemyTankController enemyTankController) : base(enemyTankController) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        state = EnemyStates.Chase;
        maxTime = 3.0f;
        timer = 0.0f;
        stuckDuration = 5.0f;
        minDistance = enemyTankController.playerChaseDistance;
    }
    public override void Tick() 
    {
        base.Tick();
        if (playerDistance <= enemyTankController.playerAttackDistance)
        {
            enemyTankController.ChangeState(EnemyStates.Attack);
            return;
        }
        CheckPlayerStuck(stuckDuration);
        MoveTowardsPlayer();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void MoveTowardsPlayer()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            if (playerDistance > minDistance)
            {
                navMeshAgent.destination = playerTransform.position;
                navMeshAgent.stoppingDistance = minDistance;
            }
            timer = maxTime;
        }
    }
}