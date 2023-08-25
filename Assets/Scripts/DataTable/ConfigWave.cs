using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConfigWaveRecord
{
    //id,listEnemy,remain,total
    public int id;
    [SerializeField]
    private string listEnemy;
    public List<int> GetListEnemyID()
    {
        List<int> ls = new List<int>();
        string[] sArray = listEnemy.Split(';');
        foreach (string s in sArray)
        {
            ls.Add(int.Parse(s));
        } 
        return ls;
    }
    public int remain;
    public int total;
    public float delayTime;
}
public class ConfigWave : BYDataTable<ConfigWaveRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigPrimarykeyCompare<ConfigWaveRecord>("id");
    }
}