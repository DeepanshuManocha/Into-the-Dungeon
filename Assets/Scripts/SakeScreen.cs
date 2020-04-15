using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SakeScreen : MonoBehaviour
{
    public Animator anim;
    public void shakeScreen()
    {
        anim.SetTrigger("hurtAnimation");
    }
}
