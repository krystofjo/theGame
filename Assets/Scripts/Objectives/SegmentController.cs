using System;
using System.Linq;
using UnityEngine;
using UnityEditor.Animations;

public class SegmentController : MonoBehaviour
{   
    public bool isSwitchedOn;
    public enum Direction {X10, Y10, Z10};
    public Direction direction;

    Animator anim;
 
    public void Start()
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
            Debug.Log("Segement Switched On");
            anim.SetBool(direction.ToString(), true);
        }
        if(!isSwitchedOn)
        {
            Debug.Log("Segement Switched Off");
            anim.SetBool("X10", false);
            anim.SetBool("Y10", false);
            anim.SetBool("Z10", false);
        }
    }
}
