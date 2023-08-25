using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_DeadAction : FSMState
{
    private Skeleton_Data data;

    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Skeleton_Data)data;
        StartCoroutine("OnStart");
    }
    public IEnumerator OnStart()
    {
        yield return new WaitForSeconds(0.1f);
        data.control.Skeleton_Databiding.Dead = true;
        yield return new WaitForSeconds(2);
        data.parent.OnDead();
        Destroy(data.control.gameObject);
    }
}
