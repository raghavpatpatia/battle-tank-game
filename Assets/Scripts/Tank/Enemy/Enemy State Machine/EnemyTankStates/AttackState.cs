using UnityEngine;

public class AttackState : EnemyTankState
{
    private float enemyRotateSpeed;
    private int enemyBPM;
    private float timeSinceShoot;
    public AttackState(EnemyTankController enemyTankController) : base(enemyTankController) { }
    public override void OnStateEnter() 
    {
        base.OnStateEnter();
        state = EnemyStates.Attack;
        enemyRotateSpeed = enemyTankController.enemyTankModel.rotationSpeed;
        enemyBPM = enemyTankController.enemyTankModel.enemyBPM;
        navMeshAgent.ResetPath();
        rb.velocity = Vector3.zero;
        timeSinceShoot = 0.0f;
    }

    public override void Tick() 
    {
        base.Tick();
        Attack();
    }
    public override void OnStateExit() 
    { 
        base.OnStateExit();
    }

    private void Attack()
    {
        Vector3 tankLookDirection = (playerTransform.position - rb.transform.position).normalized;
        rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(tankLookDirection), enemyRotateSpeed);
        if (playerDistance <= enemyTankController.playerAttackDistance)
        {
            timeSinceShoot += Time.deltaTime;
            if (timeSinceShoot > (60 / enemyBPM))
            {
                enemyTankController.Shoot();
                timeSinceShoot = 0.0f;
            }
        }
        else
        {
            enemyTankController.ChangeState(EnemyStates.Chase);
        }
    }
}