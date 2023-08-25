using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_SpawnAction : FSMState
{
    private Skeleton_Boss_Data data;
    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        StartCoroutine("OnStart");
    }
    private IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1f);
        data.parent.SwitchAction(Actionkey.IDLEBOSS, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
