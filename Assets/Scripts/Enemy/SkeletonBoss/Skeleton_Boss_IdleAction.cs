using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Skeleton_Boss_IdleAction : FSMState
{
    private Skeleton_Boss_Data data;
    private int randomSkill;
    private float dis;
    private Vector3 targetPos = Vector3.zero;
    private bool isSkill;

    public override void EnterAction(FSMData data)
    {
        this.data = (Skeleton_Boss_Data)data;
    }
    public void Update()
    {
        randomSkill = UnityEngine.Random.Range(0, 4);

        targetPos = data.control.player.transform.position;

        if (data.control.player != null)
        {
            Vector3 dir = data.control.player.transform.position - data.control.trans.position;
            if (dir.magnitude > 0)
            {
                Quaternion q = Quaternion.LookRotation(dir, Vector3.up);

                Quaternion qc = data.control.trans.localRotation;

                data.control.trans.localRotation = q;
            }

            dis = Vector3.Distance(data.control.trans.position, targetPos);
            if (dis <= 2)
            {
                OnSkillActive();
                
                if (isSkill)
                {
                    
                    switch (randomSkill)
                    {                       
                        case 1:
                            data.control.SwitchAction(Actionkey.STRONGATTACKSKILL, data);
                            break;
                        case 2:
                            data.control.SwitchAction(Actionkey.SPINSKILL, data);
                            break;
                        case 3:
                            data.control.SwitchAction(Actionkey.TELEPORTSKILL, data);
                            break;
                    }

                }
                else
                {
                    data.control.SwitchAction(Actionkey.ATTACKBOSS, data);
                }
            }
            else
                data.control.SwitchAction(Actionkey.MOVEBOSS, data);
        }
    }
    public bool OnSkillActive()
    {
        if (data.control.timeSkill <= 0)
            isSkill = true;
        else
            isSkill = false;
        return isSkill;
    }

    public override void ExitAction()
    {
        StopAllCoroutines();
        base.ExitAction();
    }

}
