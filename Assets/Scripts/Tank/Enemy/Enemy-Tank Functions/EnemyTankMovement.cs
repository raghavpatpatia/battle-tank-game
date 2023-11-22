using UnityEngine;

public class EnemyTankMovement
{
    EnemyTankController enemyTankController;
    private float minDistance = 10.0f;
    private float maxTime = 3.0f;
    private float timer = 0.0f;
    public EnemyTankMovement(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public void MoveTowardsPlayer()
    {
        enemyTankController.enemyTankView.agent.speed = enemyTankController.enemyTankModel.moveSpeed;
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sqDistance = (enemyTankController.playerTransform.position - enemyTankController.enemyTankView.agent.destination).sqrMagnitude;
            if (sqDistance > minDistance * minDistance)
            {
                enemyTankController.enemyTankView.agent.destination = enemyTankController.playerTransform.position;
            }
            timer = maxTime;
        }
    }
}