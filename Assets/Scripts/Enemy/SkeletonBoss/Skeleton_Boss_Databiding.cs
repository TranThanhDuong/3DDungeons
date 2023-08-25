using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Boss_Databiding : MonoBehaviour
{
    public Animator anim;
    private int key_Speed, key_Attack, key_Dead, key_Stun, key_SpinSkill, key_StrongAttackSkill, key_JumpSkill, key_TeleSpawnSkill;

    public float Speed
    {
        set
        {
            if (value > 0)
                anim.applyRootMotion = false;
            anim.SetFloat(key_Speed, value);
        }
    }
    public bool Attack
    {
        set
        {
            if (value)
            {
                anim.applyRootMotion = false;
                anim.SetTrigger(key_Attack);
            }
        }
    }
    public bool Dead
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_Dead);
            }
        }
    }
    public bool Stun
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_Stun);
            }
        }
    }
    public bool SpinSkill
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_SpinSkill);
            }
        }
    }
    public bool StrongAttackSkill
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_StrongAttackSkill);
            }
        }
    }
    public bool JumpSkill
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_JumpSkill);
            }
        }
    }
    public bool TeleSpawnSkill
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_TeleSpawnSkill);
            }
        }
    }
    private void Start()
    {
        key_Speed = Animator.StringToHash("SpeedMove");
        key_Attack = Animator.StringToHash("Attack");
        key_Dead = Animator.StringToHash("Dead");
        key_Stun = Animator.StringToHash("Stun");
        key_SpinSkill = Animator.StringToHash("SpinSkill");
        key_StrongAttackSkill = Animator.StringToHash("StrongAttackSkill");
        key_JumpSkill = Animator.StringToHash("JumpSkill");
        key_TeleSpawnSkill = Animator.StringToHash("TeleSpawnSkill");
    }
}