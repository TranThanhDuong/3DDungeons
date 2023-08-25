using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_ThrowAction : FSMState
{
    private Minions_Ninja_Data data;
    public override void EnterAction(FSMData data)
    {
        base.EnterAction(data);
        this.data = (Minions_Ninja_Data)data;
        StartCoroutine("Start");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        data.control.databinding.Throw = true;
        yield return new WaitForSeconds(1.5f);
        data.control.SwitchAction(Actionkey.MOVE, data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }
}
