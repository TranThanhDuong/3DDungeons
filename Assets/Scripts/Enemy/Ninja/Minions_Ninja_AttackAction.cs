using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_AttackAction : FSMState
{
    private Minions_Ninja_Data data;
    public override void EnterAction(FSMData data)
    {
        
        this.data = (Minions_Ninja_Data)data;
        StartCoroutine("Start");
    }
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        data.control.databinding.Attack = true;
        yield return new WaitForSeconds(1.5f);
        data.control.characterControl.numberCloseAttack--;
        data.control.SwitchAction(Actionkey.MOVE,data);
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        //data.character.numberCloseAttack--;
        base.ExitAction();
    }
}
