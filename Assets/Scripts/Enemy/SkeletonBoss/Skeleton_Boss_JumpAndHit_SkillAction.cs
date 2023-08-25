using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Skeleton_Boss_JumpAndHit_SkillAction : FSMState
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
        yield return new WaitForSeconds(1);
        Debug.Log("skill_jump");
        //dir to player

        Vector3 dir = data.control.player.transform.position - data.control.trans.position;
        if (dir.magnitude > 0)
        {
            Quaternion q = Quaternion.LookRotation(dir, Vector3.up);

            Quaternion qc = data.control.trans.localRotation;

            data.control.trans.localRotation = q;
        }
        //skill animation

        data.control.databiding.JumpSkill = true;
        data.control.trans.DOJump(data.control.player.transform.position, 4f, 1, 0.5f, false);

        yield return new WaitForSeconds(1);
        data.control.SwitchAction(Actionkey.IDLEBOSS, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
