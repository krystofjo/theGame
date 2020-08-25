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
            Debug.Log("SwitchedOn");
            anim.SetBool("GateOn", true);
        }
        if(!isSwitchedOn)
        {
            Debug.Log("SwitchedOff");
            anim.SetBool("GateOn", false);
        }
    }

}

