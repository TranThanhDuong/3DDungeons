using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton_SpawnAction : FSMState 
{
    private Skeleton_Data data;
    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        StartCoroutine("OnStart");
    }
    private IEnumerator OnStart()
    {       
        yield return new WaitForSeconds(0.5f);        
        data.parent.SwitchAction(Actionkey.WANDER,data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
