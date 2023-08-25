using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigEnemyRecord
{
    //id    ;public int name    ;public int hp    ;public int damage    ;public int rof    ;public int range_Attack    ;public int range_Aim
    public int id;
    public string name;
    public string prefab;
    public int hp;
    public int damage;
    public float rof;
    public float range_Attack;
    public float range_Aim;
}
public class ConfigEnemy : BYDataTable<ConfigEnemyRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigPrimarykeyCompare<ConfigEnemyRecord>("id");
    }
}
