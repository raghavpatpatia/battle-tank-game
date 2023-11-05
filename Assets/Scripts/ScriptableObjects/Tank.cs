using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject")]
public class Tank : ScriptableObject
{
    public TankTypes tankType;
    public float movementSpeed;
    public float rotationSpeed;
    public int health;
}