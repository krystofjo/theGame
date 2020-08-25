﻿using System;
using System.Linq;
using UnityEngine;



public class SegmentTrigger : MonoBehaviour
{


    [SerializeField]
    public bool isOnTrigger;
    [SerializeField]
    public bool isSwitchedOn;
    [SerializeField]
    private SegmentController[] segment;



    [SerializeField]
    public Player player;
    
    Animator anim;

        void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }

        void OnTriggerEnter(Collider other)
        {
            player = GameObject.FindGameObjectWithTag("Character").GetComponent<Player>();

            if(other.CompareTag("Character"))
            {
            isOnTrigger = true;
            player.segmentTrigger = this;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Character"))
            {
            isOnTrigger = false;
            player.segmentTrigger = null;
            }
        }

    void Update()
    {

    } 

    //initialized by Player.cs
    public void Action()
    {
        if(isSwitchedOn)
        {
            anim.SetBool("TriggerSwitcherOn", true);

            for(int i = 0; i < segment.Length; i++)
            {
                segment[i].isSwitchedOn = true;
                segment[i].UpdateStatus();
            }
        }
        
        else
        {
            anim.SetBool("TriggerSwitcherOn", false);
            
            for(int i = 0; i < segment.Length; i++)
            {
            segment[i].isSwitchedOn = false;
            segment[i].UpdateStatus();
            }
        }
    }

}