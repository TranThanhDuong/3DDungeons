using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionControl : Singleton<MissionControl>
{
    private ConfigMissionRecord configMission;
    private ConfigWaveRecord currentCFWave;
    private int indexWave;
    private List<int> idWaves;
    private List<int> idEnemies;
    private int numberEnemy;
    private int totalEnemyCreated;
    public int idMission = 1;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        //1. lay config Mission
        configMission = ConfigManager.instance.configMission.GetRecordBykeySearch(idMission);
        idWaves = configMission.GetWaveId();
        indexWave = -1;
        StartNewWave();
    }
     private void StartNewWave()
    {
        indexWave++;
        if(indexWave>=idWaves.Count)
        {
            // victory
            Debug.LogError("victory");
        }
        else
        {
            currentCFWave = ConfigManager.instance.configWave.GetRecordBykeySearch(idWaves[indexWave]);
            idEnemies = currentCFWave.GetListEnemyID();
            numberEnemy = 0;
            totalEnemyCreated = 0;

            // tao enemy 
            for(int i=0;i<currentCFWave.remain;i++)
            {
                StartCoroutine(CreateEnemy());
            }
        }
    }

    IEnumerator CreateEnemy()
    {
        numberEnemy++;
        totalEnemyCreated++;
        yield return new WaitForSeconds(currentCFWave.delayTime);
        // load resoure 
        //1. random id enemy => currentCFWave
        int idEnemy = idEnemies[UnityEngine.Random.Range(0, idEnemies.Count)];
        ConfigEnemyRecord cfEnemy = ConfigManager.instance.configEnemy.GetRecordBykeySearch(idEnemy);
        // tao enemy tu resource
        EnemyControl enemyControl = Instantiate(Resources.Load("Enemy/" + cfEnemy.prefab, typeof(EnemyControl))) as EnemyControl;

        //2. enemy action  => EnemyScenceConfig=>ConfigEnemyAction=> IDwave 
        ConfigEnemyActionRecord configEnemyAction=
            EnemyScenceConfig.instance.configEnemyAction.GetRandomActionByIDWave(currentCFWave.id);
        enemyControl.Setup(new EnemyCreateData { cfAction = configEnemyAction, cfEnemy = cfEnemy });
    }
    // Update is called once per frame
    public void OnEnemyDead(EnemyControl e)
    {
        numberEnemy--;
        Destroy(e);
        if( numberEnemy<=0 && totalEnemyCreated == currentCFWave.total)
        {
            StartNewWave();
        }
        else if (numberEnemy < currentCFWave.remain && totalEnemyCreated < currentCFWave.total)
        {
            StartCoroutine(CreateEnemy());
        }
    }
}
