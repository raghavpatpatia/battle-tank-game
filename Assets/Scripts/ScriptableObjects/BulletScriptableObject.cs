using UnityEngine;

[CreateAssetMenu(fileName = "BulletObjectList", menuName = "ScriptableObjects/BulletObjectList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bulletList;
}

[CreateAssetMenu(fileName = "BulletObject", menuName = "ScriptableObjects/BulletObject")]
public class BulletScriptableObject : ScriptableObject
{
    public int range;
    public int damage;
    public int bulletsPerShoot;
    public BulletView bulletView;
}