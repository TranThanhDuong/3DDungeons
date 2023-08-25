using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ConfigMissionRecord
{
    //id	waveid	sceneid	rewardid
    public int id;
    [SerializeField]
    private string waveid;
    public int sceneid;
    public int rewardid;
    public List<int> GetWaveId()
    {
        List<int> ls = new List<int>();
        string[] sArray = waveid.Split(';');
        foreach (string s in sArray)
        {
            ls.Add(int.Parse(s));
        }
        return ls;
    }
}
public class ConfigMission : BYDataTable<ConfigMissionRecord>
{
    public override void InitComparison()
    {
        recordCompare = new ConfigPrimarykeyCompare<ConfigMissionRecord>("id");
    }
}

