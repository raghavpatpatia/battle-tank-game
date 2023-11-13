﻿using UnityEngine;

[CreateAssetMenu(fileName = "TankObjectList", menuName = "ScriptableObjects/TankObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankList;
}

[CreateAssetMenu(fileName = "TankObject", menuName = "ScriptableObjects/TankObject")]
public class TankScriptableObject : ScriptableObject
{
    public float moveSpeed;
    public float maxRotation;
    public float health;
    public int tankDamage;
    public BulletType bulletType;
    public TankType tankType;
    public TankView tankView;
}