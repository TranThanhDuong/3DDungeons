using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class EnemyCreateData
{
    public ConfigEnemyRecord cfEnemy;
    public ConfigEnemyActionRecord cfAction;
}
public class EnemyControl : FSMSystem
{
    public bool isAlive = true;
    // Start is called before the first frame update
    public float hp = 5;
    protected float damage = 1;
    public Transform trans;
    private void Awake()
    {
        trans = transform;
    }
    public virtual void Setup(EnemyCreateData data)
    {
       
    }

    public virtual void OnDamageTarget()
    {

    }
    public virtual void OnDamageTarget(CharacterControl player, float increasing)
    {

    }
    public virtual void ApplyDamage(CharacterAttackData data,Action<object> callBack=null)
    {
     
    }
    public virtual void OnDead()
    {
        MissionControl.instance.OnEnemyDead(this);
    }
}
