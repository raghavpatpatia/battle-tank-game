using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankObjectList", menuName = "ScriptableObjects/EnemyTankObjectList")]
public class EnemyTankScriptableObjectList : ScriptableObject
{
    public EnemyTankScriptableObject[] enemyTankList;
}

[CreateAssetMenu(fileName = "EnemyTankObject", menuName = "ScriptableObjects/EnemyTankObject")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public float rotationSpeed;
    public float health;
    public int enemyBPM;
    public float minimumPlayerDistanceToAttack;
    public float minimumPlayerDistanceToChase;
    public EnemyTanks enemyTankType;
    public BulletType bulletType;
    public EnemyTankView enemyTankView;
}