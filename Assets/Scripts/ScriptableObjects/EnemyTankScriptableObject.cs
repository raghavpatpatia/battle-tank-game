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
    public int tankDamage;
    public float health;
    public EnemyTanks enemyTankType;
    public BulletType bulletType;
    public TankType tankType;
    public EnemyTankView enemyTankView;
}