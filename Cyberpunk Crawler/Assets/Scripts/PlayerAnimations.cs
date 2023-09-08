using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void SetAnimationStatus(string animationName, bool status)
    {
        anim.SetBool(animationName, status);
    }
}
