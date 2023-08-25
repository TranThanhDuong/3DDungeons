using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Databiding : MonoBehaviour
{
    public Animator anim;
    private int key_Speed, key_Attack, key_Dead, key_GetHit;

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
    public bool GetHit
    {
        set
        {
            if (value)
            {
                anim.SetTrigger(key_GetHit);
            }
        }
    }
    private void Start()
    {
        key_Speed = Animator.StringToHash("SpeedMove");
        key_Attack = Animator.StringToHash("Attack");
        key_Dead = Animator.StringToHash("Dead");
        key_GetHit = Animator.StringToHash("GetHit");
    }
}
