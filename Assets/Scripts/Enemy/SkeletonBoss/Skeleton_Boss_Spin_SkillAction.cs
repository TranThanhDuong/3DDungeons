using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_Spin_SkillAction : FSMState
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
        Debug.Log("skill_spin");
        data.control.databiding.SpinSkill = true;
        yield return new WaitForSeconds(1);
        data.control.OnDamageTarget(data.control.player, 1.5f);
        yield return new WaitForSeconds(1);
        data.control.SwitchAction(Actionkey.IDLEBOSS, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }

}
