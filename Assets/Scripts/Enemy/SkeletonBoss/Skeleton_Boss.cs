using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Skeleton_Boss_Data : FSMData
{
    public EnemyControl parent;
    public EnemyCreateData createData;
    public Skeleton_Boss control;
    public CharacterControl character;

}
public class Skeleton_Boss : EnemyControl
{
    public Skeleton_Boss_Databiding databiding;
    private List<int> listEA;
    private EnemyActionPoint currentEnemyActionPoint;
    private EnemyCreateData data;
    public CharacterControl player;
    private int currentIndex = 0;
    public event Action<float> OnHPBossChange;
    public float currentHPBoss;
    public float currentHPBossPercent;
    public float maxHPBoss;
    
    public float timeSkill = 3;
    public NavMeshAgent agent;
    public override void Setup(EnemyCreateData data)
    {
        this.data = data;
        listEA = data.cfAction.GetLisPoint();
        int idPoint = listEA[currentIndex];
        currentEnemyActionPoint = EnemyScenceConfig.instance.GetPointById(idPoint);
        trans.position = currentEnemyActionPoint.transform.position;
        agent = gameObject.AddComponent<NavMeshAgent>();
        hp = 10;
        currentHPBoss = hp;
        maxHPBoss = currentHPBoss;
        SwitchAction(Actionkey.SPAWNBOSS, new Skeleton_Boss_Data { parent = this, control = this });
        
    }

    public void Update()
    {
        TimeSKillCountDown();
    }
    public float TimeSKillCountDown()
    {
        timeSkill -= Time.deltaTime;
        if (timeSkill <= -6)
        {
            timeSkill = 6 ;
        }
        return timeSkill;
    }

    public override void OnDamageTarget()
    {
        base.OnDamageTarget();
        if (player != null && player.IsAlive && Vector3.Distance(this.trans.position, player.transform.position) < 3)
        {
            player.OnTakingDamage(damage);
        }
    }

    public override void OnDamageTarget(CharacterControl p, float increasing)
    {
        base.OnDamageTarget();
        if (p != null && p.IsAlive && Vector3.Distance(this.trans.position, p.transform.position) < 3)
        {
            p.OnTakingDamage(damage * increasing);
        }
    }

    public EnemyActionPoint GetNextIdPoint()
    {
        currentIndex++;
        if (currentIndex >= listEA.Count)
        {
            currentIndex = 0;
        }
        return EnemyScenceConfig.instance.GetPointById(listEA[currentIndex]);
    }
    public override void ApplyDamage(CharacterAttackData data, Action<object> callBack = null)
    {
        if (!isAlive)
            return;

        currentHPBoss -= data.damage;
        currentHPBossPercent = (float)currentHPBoss / (float)maxHPBoss;
        OnHPBossChange?.Invoke(currentHPBossPercent);
        if (currentHPBoss <= 0)
        {
            isAlive = false;
            SwitchAction(Actionkey.DEADBOSS, new Skeleton_Boss_Data { parent = this, control = this });
            callBack?.Invoke(this);
        }
          
        
    }
    public void NavMeshMove(Vector3 targetPos)
    {
        agent.SetDestination(targetPos);
        databiding.anim.applyRootMotion = false;
        databiding.Speed = 1;

    }

    public void RootMotionMove()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (!isAlive)
            return;

        player = other.GetComponent<CharacterControl>();

        if (player != null)
        {
            SwitchAction(Actionkey.IDLEBOSS, new Skeleton_Boss_Data { parent = this, control = this });
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (!isAlive)
            return;

        SwitchAction(Actionkey.MOVEBOSS, new Skeleton_Boss_Data { parent = this, control = this });
    }

   

}
