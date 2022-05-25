using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacionpuerta : MonoBehaviour
{
    public Animator animator;

    public void ActionOpenDoor()
    {
        animator.SetTrigger("open");
    }
}
