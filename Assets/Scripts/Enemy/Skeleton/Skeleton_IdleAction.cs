using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_IdleAction : FSMState
{

    private Skeleton_Data data;
    private EnemyActionPoint currentEAP;
    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        currentEAP = this.data.control.GetNextIdPoint();
        this.data.control.agent.enabled = true;
        StartCoroutine("OnStart");
    }
    private IEnumerator OnStart()
    {
        if (data.control.player != null)
        {          
            yield return new WaitForSeconds(1);
            data.control.SwitchAction(Actionkey.ATTACK, data);
        }
        else
        {
            yield return new WaitForSeconds(5);
            data.control.SwitchAction(Actionkey.WANDER, data);
        }
            

    }
    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }


}

