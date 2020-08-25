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
        if(isSwitchedOn)
        {   
            anim.SetBool("GateOn", true);
        }
        if(!isSwitchedOn)
        {
            anim.SetBool("GateOn", false);
        }
    }
    public void UpdateStatus()
    {  
        if(isSwitchedOn)
        {   
            anim.SetBool("GateOn", true);
        }
        if(!isSwitchedOn)
        {
            anim.SetBool("GateOn", false);
        }
    }

}

