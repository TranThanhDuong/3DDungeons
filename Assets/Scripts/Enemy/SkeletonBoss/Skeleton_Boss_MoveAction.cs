using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_MoveAction : FSMState
{
    private Skeleton_Boss_Data data;
    public Vector3 targetPos=Vector3.zero;
    private float dis;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        this.data.control.agent.enabled = true;
    }

    public void Update()
    {
        targetPos = data.control.player.transform.position;
        data.control.databiding.Speed = 1;
        data.control.NavMeshMove(targetPos);
        data.control.agent.speed = 2;
        dis = Vector3.Distance(data.control.trans.position, targetPos);
        if (dis == 3)
        {
            data.control.SwitchAction(Actionkey.JUMPBOSSSKILL, data);
        }
        else if (dis<=1.5)
        {
            data.control.agent.velocity = Vector3.zero;
            data.control.databiding.Speed = 0;
            data.control.SwitchAction(Actionkey.ATTACKBOSS, data);
        }
        
    }

    public override void ExitAction()
    {
        base.ExitAction();
    }

}
