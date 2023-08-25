using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_IdleAction : FSMState
{
    private Minions_Ninja_Data data;
    private EnemyActionPoint current;
    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Minions_Ninja_Data)data;
        StartCoroutine("Start");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        //data.character.numberCloseAttack = 0;
        EnemyActionPoint eap = data.control.GetNextIdPoint();
        //if(data.control.currentEAP >= data.control.listEA.Count)
        if(eap == null || eap.EAPtype != EAP_Type.JUMP)
        {
            if(eap != null)
                Debug.LogError("da vao day " + eap.EAPtype.ToString());
            data.control.SwitchAction(Actionkey.MOVE, data);
        }
        else
        {
            data.control.SwitchAction(Actionkey.JUMP, data);
        }
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
