using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Minions_Ninja_StunAction : FSMState
{
    private Minions_Ninja_Data data;
    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Minions_Ninja_Data)data;
        
    }
    private void Update()
    {
        Vector3 dir = data.control.transform.position - data.control.attackData.trans.position;
        float dis = Vector3.Distance(data.control.transform.position, data.control.attackData.trans.position);
        if (dis > 0)
        {
            Vector3 posAim = data.control.transform.position + dir.normalized * data.control.attackData.force / dis;
            data.control.databinding.Stun = true;
            data.control.transform.DOMove(posAim, 0.05f).SetEase(Ease.InFlash);
        }
        data.control.databinding.animator.applyRootMotion = false;
        data.control.SwitchAction(Actionkey.MOVE, data);
    }
}
