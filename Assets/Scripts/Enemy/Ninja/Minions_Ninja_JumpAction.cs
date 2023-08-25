using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Minions_Ninja_JumpAction : FSMState
{
    private Minions_Ninja_Data data;
    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Minions_Ninja_Data)data;
        StartCoroutine("Start");
       

    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        data.control.agent.enabled = false;
        Debug.LogError("test " + data.control.currentEAP);
        int id = data.control.listEA[data.control.currentEAP];
        EnemyActionPoint actionPoint = EnemyScenceConfig.instance.GetPointById(id);
        data.control.trans.forward = actionPoint.transform.forward;

        

        yield return new WaitForSeconds(1);
        data.control.trans.DOJump(actionPoint.transform.position,4f,1,1,false);
        data.control.databinding.Jump = true;
        
        yield return new WaitForSeconds(1);
        
        data.control.agent.Warp(data.control.transform.position);
        data.control.SwitchAction(Actionkey.IDLE, data);
    }

    public override void ExitAction()
    {
        base.ExitAction();
        StopAllCoroutines();
    }
}
