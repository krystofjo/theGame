using System;
using System.Linq;
using UnityEngine;



public class GateController : MonoBehaviour
{
    public bool isSwitchedOn;
    public Animator anim;

    void Start()
   {
        anim = GetComponentInChildren<Animator>();
    }
    public void UpdateStatus()
    {  
        if(isSwitchedOn)
        {
            anim.Play("Open");
        }
        if(!isSwitchedOn)
        {
            anim.Play("Close");
        }
    }

}

