using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_AttackAction : FSMState
{
    private Skeleton_Boss_Data data;
    private float dis;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        this.data.control.agent.enabled = false;
        StartCoroutine("OnStart");
    }

    public IEnumerator OnStart()
    {

        Vector3 dir = data.control.player.transform.position - data.control.trans.position;
        if (dir.magnitude > 0)
        {
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);

            Quaternion qc = data.control.trans.localRotation;

            data.control.trans.localRotation = q;
        }


        dis = Vector3.Distance(data.control.player.transform.position, data.control.trans.position);
        if (dis > 2)
        {
            data.control.SwitchAction(Actionkey.MOVEBOSS, data);
        }
        else
        {
            data.control.databiding.Attack = true;
            yield return new WaitForSeconds(1);
            data.control.OnDamageTarget();
            yield return new WaitForSeconds(1);            
            data.control.SwitchAction(Actionkey.IDLEBOSS, data);
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