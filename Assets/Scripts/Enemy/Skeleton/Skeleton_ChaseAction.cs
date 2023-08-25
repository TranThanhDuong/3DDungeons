using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_ChaseAction : FSMState
{
    private Skeleton_Data data;
    private float dis;
    Vector3 targetPos = Vector3.zero;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        this.data.control.agent.enabled = true;
        this.data.control.Skeleton_Databiding.anim.applyRootMotion = false;
    }

    private void Update()
    {
        
        //setting agent

        targetPos = data.control.player.transform.position;      
        data.control.agent.SetDestination(targetPos);
        data.control.agent.speed = 4f;
        data.control.agent.angularSpeed = 360;
        data.control.Skeleton_Databiding.Speed = 1;
        data.control.agent.stoppingDistance = 1;

        //

        dis = Vector3.Distance(data.control.player.transform.position, data.control.trans.position);
        if (dis <= 1.5f)
        {
            data.control.agent.velocity = Vector3.zero;
            data.control.Skeleton_Databiding.Speed = 0;
            data.parent.SwitchAction(Actionkey.ATTACK, data);          
        }
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (data.control.trans != null)
        {
            UnityEditor.Handles.color = Color.yellow;
            UnityEditor.Handles.DrawLine(data.control.player.transform.position, data.control.trans.position);
        }


    }
#endif
}
