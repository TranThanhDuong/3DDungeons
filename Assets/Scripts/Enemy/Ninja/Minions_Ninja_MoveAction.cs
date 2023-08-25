using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minions_Ninja_MoveAction : FSMState
{
    private Minions_Ninja_Data data;
    private float distance;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;
    public bool isOk;

    public override void EnterAction(FSMData data)
    {
        this.data = (Minions_Ninja_Data)data;
        isOk = false;
        StartCoroutine("Start");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        data.control.agent.enabled = true;
        isOk = true;
    }

    private void Update()
    {
        if (!isOk)
            return;

        distance = Vector3.Distance(data.control.player.transform.position, data.control.trans.position);

        data.control.agent.destination = data.control.player.position;
        data.control.databinding.SpeedMove = 1f;
        data.control.agent.speed = 3f;

        Vector3 dir = data.control.agent.steeringTarget - data.control.trans.position;
        dir.Normalize();

        Quaternion q = Quaternion.LookRotation(dir, Vector3.up);

        data.control.trans.localRotation = Quaternion.RotateTowards(data.control.trans.localRotation,q,Time.deltaTime * 360);


        //-------------------------------------------------------------
        //if (distance <= data.control.agent.stoppingDistance)
        //{
        //    Vector3 look = (data.control.player.position - transform.position).normalized;
        //    Quaternion lookRotate = Quaternion.LookRotation(new Vector3(look.x, 0, look.z));
        //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotate, Time.deltaTime * 4f);
        //}


        //
        //transform.position = data.control.agent.nextPosition;

        //-------------------------------------------------------------

        //if (distance <= 2)
        //{
        //    data.control.databinding.SpeedMove = 0;
        //    data.control.SwitchAction(Actionkey.ATTACK, data);
        //}

        //-------------------------------------------------------------
        if (distance <= 10)
        {
            if (data.control.characterControl.numberCloseAttack <= 2)
            {
                if(distance <= 2)
                {
                    data.control.characterControl.numberCloseAttack++;
                    data.control.databinding.SpeedMove = 0;
                    data.control.SwitchAction(Actionkey.ATTACK, data);
                }
            }
            else
            {
                data.control.databinding.SpeedMove = 0;
                data.control.SwitchAction(Actionkey.THROW, data);
            }
        }

    }
    public override void ExitAction()
    {
        StopAllCoroutines();
        data.control.agent.enabled = false;
        base.ExitAction();
    }
}