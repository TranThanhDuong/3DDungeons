using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_StunAction : FSMState
{
    private Skeleton_Boss_Data data;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        StartCoroutine("OnStart");

    }
    public IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("skill_stun");
        data.control.databiding.Stun = true;
        yield return new WaitForSeconds(1);
        data.control.SwitchAction(Actionkey.IDLEBOSS, data);
    }

}
