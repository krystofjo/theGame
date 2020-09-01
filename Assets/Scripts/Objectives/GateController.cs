using System;
using System.Linq;
using UnityEngine;



public class GateController : MonoBehaviour
{
    public bool isSwitchedOn;
    Animator anim;

    void Start()
   {
        anim = GetComponentInChildren<Animator>();
        if(isSwitchedOn)
        {
        UpdateStatus();
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

