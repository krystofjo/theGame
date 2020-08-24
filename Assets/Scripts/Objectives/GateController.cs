using System;
using System.Linq;
using UnityEngine;



public class GateController : MonoBehaviour
{
    public bool isSwitchedOn;
    private Animator anim;

    void Start()
   {
        anim = GetComponentInChildren<Animator>();
    }
    public void UpdateStatus()
    {  
        Debug.Log("Door Status Updated");
        if(isSwitchedOn)
        {
        anim.Play("CubeOpen");
        }
        if(!isSwitchedOn)
        {
        anim.Play("CubeClosed");
        }
    }

}

