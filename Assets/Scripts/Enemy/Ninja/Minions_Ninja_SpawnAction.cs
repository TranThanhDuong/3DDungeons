using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_SpawnAction_Duong : FSMState
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
        data.control.particle.Play();
        yield return new WaitForSeconds(2);
        data.control.particle.Stop();
        data.control.SwitchAction(Actionkey.IDLE,data);
    }

    public override void ExitAction()
    {
        base.ExitAction();
        StopAllCoroutines();
    }
}
