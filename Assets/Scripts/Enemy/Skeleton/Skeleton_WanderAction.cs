using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skeleton_WanderAction : FSMState
{
    private Skeleton_Data data;
    private EnemyActionPoint currentEAP;
    Vector3 targetPos = Vector3.zero;
    private float dis;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        currentEAP = this.data.control.GetNextIdPoint();
        this.data.control.agent.enabled = true;
        //next pos info
        targetPos = currentEAP.transform.position;
    }
    private void Update()
    {
        //Nav mesh move  
        data.control.agent.SetDestination(targetPos);
        data.control.agent.speed = 1;
        data.control.Skeleton_Databiding.Speed = 0.5f;     
        // changeAction from current EAP to next EAP
        dis = Vector3.Distance(targetPos, data.control.trans.position);
        if (dis < 1)
        {
            data.control.agent.velocity = Vector3.zero;
            data.control.SwitchAction(Actionkey.IDLE, data);
        }
    }
   
    public override void ExitAction()
    {
        StopAllCoroutines();
        data.control.Skeleton_Databiding.Speed = 0f;
        base.ExitAction();
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (data.control.trans != null)
        {
            UnityEditor.Handles.color = Color.yellow;
            UnityEditor.Handles.DrawLine(currentEAP.transform.position, data.control.trans.position);
        }

    }
#endif

}
