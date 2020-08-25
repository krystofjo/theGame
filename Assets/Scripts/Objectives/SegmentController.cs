﻿using System;
using System.Linq;
using UnityEngine;

public class SegmentController : MonoBehaviour
{   
    public bool isSwitchedOn;
    public int value;

    // Animate the position and color of the GameObject
    public void Start()
    {
        Animation anim = GetComponent<Animation>();
        AnimationCurve curve;

        // create a new AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
        Keyframe[] keys;
        keys = new Keyframe[3];
        keys[0] = new Keyframe(0.0f, 0.0f);
        keys[1] = new Keyframe(1.0f, 1.5f);
    
        curve = new AnimationCurve(keys);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curve);

        // update the clip to a change the red color
        curve = AnimationCurve.Linear(0.0f, 1.0f, 2.0f, 0.0f);
        clip.SetCurve("", typeof(Material), "_Color.r", curve);

        // now animate the GameObject
        anim.AddClip(clip, clip.name);
        anim.Play(clip.name);
    }


    public void UpdateStatus()
    {  
        if(isSwitchedOn)
        {   
            Debug.Log("Segement Switched On");
            //anim.SetBool("GateOn", true);
        }
        if(!isSwitchedOn)
        {
            Debug.Log("Segement Switched Off");
            //anim.SetBool("GateOn", false);
        }
    }
}
