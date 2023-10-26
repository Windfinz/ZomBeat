using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/Enemy") ]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    float health;
    public float Health { get => health; private set => health = value; }


}
