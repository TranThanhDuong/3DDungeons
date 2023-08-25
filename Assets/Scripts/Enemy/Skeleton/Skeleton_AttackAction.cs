using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_AttackAction : FSMState
{
    private Skeleton_Data data;
    private bool isAttack;
    private float dis;
    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        this.data.control.agent.enabled = false;
        StartCoroutine("OnStart");
    }

    public void Update()
    {
        
     
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
        if(dis>2f)
        {
            data.control.SwitchAction(Actionkey.CHASE, data);
        }
        else
        {            
            data.control.Skeleton_Databiding.Attack = true;
            yield return new WaitForSeconds(1f);
            data.control.OnDamageTarget();
            yield return new WaitForSeconds(1f);
            data.control.SwitchAction(Actionkey.IDLE, data);
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
