using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_DeadAction : FSMState
{
    private Skeleton_Boss_Data data;

    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Skeleton_Boss_Data)data;
        StartCoroutine("OnStart");
    }
    public IEnumerator OnStart()
    {
        yield return new WaitForSeconds(0.1f);
        data.control.databiding.Dead = true;
        yield return new WaitForSeconds(3);
        data.parent.OnDead();
        Destroy(data.control.gameObject);
    }
}
