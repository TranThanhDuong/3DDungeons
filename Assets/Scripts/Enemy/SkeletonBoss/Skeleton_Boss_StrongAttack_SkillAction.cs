using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_StrongAttack_SkillAction : FSMState
{
    private Skeleton_Boss_Data data;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        this.data.control.agent.enabled = false;
        StartCoroutine("OnStart");

    }
    public IEnumerator OnStart()
    {
        Debug.Log("skill_strong");
        Vector3 dir = data.control.player.transform.position - data.control.trans.position;
        if (dir.magnitude > 0)
        {
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);

            Quaternion qc = data.control.trans.localRotation;

            data.control.trans.localRotation = q;
        }
        yield return new WaitForSeconds(1);
        data.control.databiding.StrongAttackSkill = true;
        yield return new WaitForSeconds(1);
        data.control.OnDamageTarget(data.control.player, 1.5f);
        yield return new WaitForSeconds(1);
        data.control.SwitchAction(Actionkey.IDLEBOSS, data);
    }

}
