using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_DeadAction : FSMState
{
    private Minions_Ninja_Data data;
    
    public override void EnterAction(FSMData data)
    {
        this.data = (Minions_Ninja_Data)data;
        StartCoroutine("Start");
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        data.control.OnDead();
        data.control.databinding.Dead = true;
        data.control.isAlive = false;
        yield return new WaitForSeconds(3);
        Destroy(data.control.trans.gameObject);
    }

    public override void ExitAction()
    {
        base.ExitAction();
        StopAllCoroutines();
    }
}
