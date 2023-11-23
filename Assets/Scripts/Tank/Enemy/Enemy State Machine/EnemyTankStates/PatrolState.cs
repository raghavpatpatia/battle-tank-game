using UnityEngine;

public class PatrolState : EnemyTankState
{
    private float enemyPatrolRange;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private float stuckDuration;

    public PatrolState(EnemyTankController enemyTankController) : base(enemyTankController) { }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        state = EnemyStates.Patrol;
        enemyPatrolRange = 10.0f;
        stuckDuration = 5.0f;
        startingPosition = rb.transform.position;
        roamPosition = GetRoamPosition();
    }
    public override void Tick() 
    {
        base.Tick();
        if (playerDistance <= enemyTankController.playerChaseDistance)
        {
            enemyTankController.ChangeState(EnemyStates.Chase);
            return;
        }
        CheckPlayerStuck(stuckDuration);
        Patrol();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void Patrol()
    {
        float distanceToRoamPosition = Vector3.Distance(rb.transform.position, roamPosition);
        if (distanceToRoamPosition < 1.0f)
        {
            roamPosition = GetRoamPosition();
            startingPosition = rb.transform.position;
        }
        navMeshAgent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamPosition()
    {
        return startingPosition + GetRandomPoint() * enemyPatrolRange;
    }

    private Vector3 GetRandomPoint()
    {
        return new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)).normalized;
    }
}