using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Skeleton_GetHitAction : FSMState
{
    private Skeleton_Data data;
    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Data)data;
        StartCoroutine("OnStart");
    }
    private IEnumerator OnStart()
    {
        yield return new WaitForSeconds(0.1f);

        //Vector3 dir = data.control.trans.position - data.control.player.transform.position;
        //float dis = Vector3.Distance(data.control.trans.position, data.control.player.transform.position);
        //Vector3 posAim = data.control.trans.position + dir.normalized * data.control.attackData.force / dis;
        //transform.DOMove(posAim, 0.05f).SetEase(Ease.InFlash);

        data.control.Skeleton_Databiding.GetHit = true;
        yield return new WaitForSeconds(1);
        data.parent.SwitchAction(Actionkey.IDLE, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
