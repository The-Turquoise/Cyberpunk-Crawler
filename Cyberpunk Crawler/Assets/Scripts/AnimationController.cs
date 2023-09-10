using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
    public void StartAttack()
    {
        anim.SetTrigger("IsAttacking");
    }
    public void StartJump()
    {
        anim.SetTrigger("IsJumping");
    }
    
    public void StartMove(bool isRunning)
    {
        anim.SetBool("IsRunning", isRunning);
    }
}
