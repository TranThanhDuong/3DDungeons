using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConfigManager : Singleton<ConfigManager>
{
    private ConfigMission configMission_;
    public ConfigMission configMission
    {
       private set
        {
            configMission_ = value;
        }
        get
        {
            return configMission_;
        }
    }
    private ConfigWave configWave_;
    public ConfigWave configWave
    {
        private set
        {
            configWave_ = value;
        }
        get
        {
            return configWave_;
        }
    }
    private ConfigEnemy configEnemy_;
    public ConfigEnemy configEnemy
    {
        private set
        {
            configEnemy_ = value;
        }
        get
        {
            return configEnemy_;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Init(null));
    }

    IEnumerator Init(Action callback)
    {
        configMission = Resources.Load("DataTable/ConfigMission", typeof(ScriptableObject)) as ConfigMission;
        yield return new WaitUntil(() => configMission != null);
        configWave = Resources.Load("DataTable/ConfigWave", typeof(ScriptableObject)) as ConfigWave;
        yield return new WaitUntil(() => configWave != null);
        configEnemy = Resources.Load("DataTable/ConfigEnemy", typeof(ScriptableObject)) as ConfigEnemy;
        yield return new WaitUntil(() => configEnemy != null);
        Debug.Log("Init Config done!!!");
        callback?.Invoke();
    }
}
