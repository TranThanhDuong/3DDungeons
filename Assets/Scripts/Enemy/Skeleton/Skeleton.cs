using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using DG.Tweening;

public class Skeleton_Data : FSMData
{
    public EnemyControl parent;
    public EnemyCreateData createData;
    public Skeleton control;
    public CharacterControl character;
    
}
public class Skeleton : EnemyControl
{
    
    private List<int> listEA;
    private EnemyActionPoint currentEnemyActionPoint;
    private EnemyCreateData data;
    public CharacterControl player;
    private int currentIndex=0;
    public Skeleton_Databiding Skeleton_Databiding;
    public NavMeshAgent agent;
    public float timeCount;
    public event Action<float> OnHPChange;
    public float currentHP;
    public float currentHPPercent;
    public float maxHP; 
    public override void Setup(EnemyCreateData data)
    {
        this.isAlive = true;
        this.data = data;
        listEA = data.cfAction.GetLisPoint();
        int idPoint = listEA[currentIndex];
        currentEnemyActionPoint = EnemyScenceConfig.instance.GetPointById(idPoint);
        trans.position = currentEnemyActionPoint.transform.position;
        agent = gameObject.AddComponent<NavMeshAgent>();
        currentHP = data.cfEnemy.hp;
        maxHP = currentHP;
        damage = data.cfEnemy.damage;
        SwitchAction(Actionkey.SPAWN, new Skeleton_Data { parent = this, control = this });       
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

        currentHP -= data.damage;
        currentHPPercent = (float)currentHP / (float)maxHP;
        OnHPChange?.Invoke(currentHPPercent);
        if (currentHP>0)
        {
            
            SwitchAction(Actionkey.GETHIT, new Skeleton_Data { parent = this, control = this });
            Vector3 dir = transform.position - data.trans.position;
            float dis = Vector3.Distance(transform.position, data.trans.position);
            Vector3 posAim = transform.position + dir.normalized * data.force / dis;
            transform.DOMove(posAim, 0.05f).SetEase(Ease.InFlash);
        }
       else
        {
            currentHP = 0;
            isAlive = false;
            SwitchAction(Actionkey.DEAD, new Skeleton_Data { parent = this, control = this });
            callBack?.Invoke(this);
        }
    }

    public override void OnDamageTarget()
    {
        base.OnDamageTarget();
        if(player != null && player.IsAlive && Vector3.Distance(this.trans.position, player.transform.position) < 3)
        {
            player.OnTakingDamage(damage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isAlive)
            return;

        player = other.GetComponent<CharacterControl>();
        
        if (player != null)
        {
            SwitchAction(Actionkey.CHASE, new Skeleton_Data { parent = this, control = this });
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (!isAlive)
            return;

        SwitchAction(Actionkey.SPAWN, new Skeleton_Data { parent = this, control = this });
    }


}

