using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class ConfigEnemyActionRecord
{
    //id,listPoint
    public int id;
    public int idWave;

    [SerializeField]
    private string listPoint;
    public List<int> GetLisPoint()
    {
        List<int> ls = new List<int>();
        string[] sArray = listPoint.Split(';');
        foreach(string s in sArray)
        {
            ls.Add(int.Parse(s));
        }
        return ls;
    }
}
public class ConfigEnemyAction : BYDataTable<ConfigEnemyActionRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigPrimarykeyCompare<ConfigEnemyActionRecord>("id");
    }
    public List<ConfigEnemyActionRecord> GetActionSByIDWave(int idwave)
    {
       return records.Where((r) => r.idWave == idwave).ToList();
    }
    public ConfigEnemyActionRecord GetRandomActionByIDWave(int idwave)
    {
        List<ConfigEnemyActionRecord> ls= records.Where((r) => r.idWave == idwave).ToList();
        int i = UnityEngine.Random.Range(0, ls.Count);
        return ls[i];
    }
    public ConfigEnemyActionRecord GetActionByIdWaveAndNumberAction(int idwave, int numberAction)
    {
        List<ConfigEnemyActionRecord> ls = records.Where((r) => r.idWave == idwave).ToList();
        if (numberAction < 0 || numberAction >= ls.Count) return null;
        return ls[numberAction];
    }
}
