using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Minions_Ninja_Data : FSMData
{
    public Minions_Ninja control;
}

public class Minions_Ninja : EnemyControl
{
    public List<int> listEA;
    public int currentEAP = 0;
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask enemyMask;
    public CharacterAttackData attackData;
    public CharacterControl characterControl;
    public LayerMask characterMask;
    public ParticleSystem particle;
    public Minions_Ninja_Databinding databinding;

    public override void Setup(EnemyCreateData data)
    {
        
        base.Setup(data);
        listEA = data.cfAction.GetLisPoint();
        int idPoint = listEA[currentEAP];
        EnemyActionPoint enemyActionPoint = EnemyScenceConfig.instance.GetPointById(idPoint);
        trans.position = enemyActionPoint.transform.position;
        SwitchAction(Actionkey.SPAWN, new Minions_Ninja_Data { control = this });
        player = GameObject.FindGameObjectWithTag("Player").transform;
        characterControl = player.GetComponent<CharacterControl>();
        characterControl.numberCloseAttack = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.Warp(transform.position);
        agent.enabled = false;
    }

    private void Update()
    {
       
    }
    public override void ApplyDamage(CharacterAttackData data, Action<object> callBack = null)
    {
        
        hp -= data.damage;
       


        if (hp <= 0)
        {
            SwitchAction(Actionkey.DEAD, new Minions_Ninja_Data { control = this });
            callBack?.Invoke(this);
        }
        else
        {
            attackData = data;

            SwitchAction(Actionkey.STUN, new Minions_Ninja_Data {  control = this });
            
        }
    }

    public EnemyActionPoint GetNextIdPoint()
    {
        if (currentEAP + 1 < listEA.Count)
        {
            return EnemyScenceConfig.instance.GetPointById(listEA[++currentEAP]);
        }

        return null;
    }
  
    public override void OnDead()
    {
        base.OnDead();
    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;
    }
}
