using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Ninja_Sensei : EnemyControl
{
    public override void Setup(EnemyCreateData data)
    {
        base.Setup(data);
        int idPoint = data.cfAction.GetLisPoint()[0];
        EnemyActionPoint enemyActionPoint = EnemyScenceConfig.instance.GetPointById(idPoint);
        trans.position = enemyActionPoint.transform.position;
    }
}
