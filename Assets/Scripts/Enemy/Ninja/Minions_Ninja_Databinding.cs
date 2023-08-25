using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions_Ninja_Databinding : MonoBehaviour
{
    private int key_SpeedMove;
    private int key_Dead;
    private int key_Attack;
    private int key_Jump;
    private int key_Stun;
    private int key_Throw;
    public Animator animator;

    public bool Dead
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(key_Dead);
            }
        }
    }
    public bool Jump
    {
        set
        {
            if(value)
            {
                animator.SetTrigger(key_Jump);
            }
        }
    }
    public bool Attack
    {
        set
        {
            if(value)
            {
                animator.SetTrigger(key_Attack);
            }
        }
    }
    public bool Stun
    {
        set
        {
            if (value)
            {
                animator.SetTrigger(key_Stun);
            }
        }
    }
    public bool Throw
    {
        set
        {
            animator.SetTrigger(key_Throw);
        }
    }
    public float SpeedMove
    {
        set
        {
            animator.SetFloat(key_SpeedMove, value);
        }
    }

    public void Start()
    {
        key_Dead = Animator.StringToHash("Dead");
        key_SpeedMove = Animator.StringToHash("SpeedMove");
        key_Attack = Animator.StringToHash("Attack");
        key_Jump = Animator.StringToHash("Jump");
        key_Stun = Animator.StringToHash("Stun");
        key_Throw = Animator.StringToHash("ThrowAttack");
    }
}
