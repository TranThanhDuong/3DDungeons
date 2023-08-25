using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Skeleton_Boss_Teleport_SkillAction : FSMState
{
    private Skeleton_Boss_Data data;
    private float disTele = 5;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
        this.data.control.agent.enabled = false;
        StartCoroutine("OnStart");

    }
    public IEnumerator OnStart()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("skill_tele");
        Vector3 dir = data.control.player.transform.position - data.control.trans.position;
        Vector3 posTele = data.control.trans.position - dir.normalized * disTele;
        data.control.trans.DOMove(posTele, 0.1f,false);
        data.control.databiding.Speed = 0;
        data.control.databiding.TeleSpawnSkill = true;

        //spawn minions around player

        yield return new WaitForSeconds(3);
        data.control.SwitchAction(Actionkey.IDLEBOSS, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }

}
