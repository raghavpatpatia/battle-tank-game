using UnityEngine;
using UnityEngine.AI;

public class EnemyTankState
{
    protected EnemyTankController enemyTankController;
    protected Rigidbody rb;
    protected NavMeshAgent navMeshAgent;
    protected Transform playerTransform;
    protected EnemyStates state;

    public EnemyTankState(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
        rb = enemyTankController.rb;
        playerTransform = enemyTankController.playerTransform;
        navMeshAgent = enemyTankController.agent;
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
    public virtual void Tick() { }
}