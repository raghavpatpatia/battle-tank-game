using UnityEngine;
using UnityEngine.AI;

public class EnemyTankState
{
    protected EnemyTankController enemyTankController;
    protected Rigidbody rb;
    protected NavMeshAgent navMeshAgent;
    protected Transform playerTransform;
    protected float playerDistance;
    protected EnemyStates state;
    private bool isActive = false;
    public bool IsActive
    {
        get { return isActive; }
    }
    public EnemyStates EnemyState
    {
        get { return state; }
    }

    public EnemyTankState(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
        rb = enemyTankController.rb;
        playerTransform = enemyTankController.playerTransform;
        navMeshAgent = enemyTankController.agent;
        navMeshAgent.speed = enemyTankController.enemyTankModel.moveSpeed;
    }

    public virtual void OnStateEnter() 
    {
        isActive = true;
        UpdatedPlayerDistance();
    }
    public virtual void Tick() 
    {
        if (playerTransform == null)
        {
            navMeshAgent.ResetPath();
            rb.velocity = Vector3.zero;
        }
        else
        {
            UpdatedPlayerDistance();
        }
    }
    public virtual void OnStateExit() 
    {
        isActive = false;
    }
    private void UpdatedPlayerDistance()
    {
        this.playerDistance = Vector3.Distance(playerTransform.position, rb.transform.position);
    }

    protected void CheckPlayerStuck(float stuckDuration)
    {
        Vector3 previousPlayerPosition = playerTransform.position;
        stuckDuration -= Time.deltaTime;

        if (stuckDuration <= 0.0f)
        {
            enemyTankController.ChangeState(EnemyStates.Idle);
        }
        previousPlayerPosition = playerTransform.position;
    }
}