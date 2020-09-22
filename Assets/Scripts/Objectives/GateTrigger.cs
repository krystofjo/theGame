using System;
using System.Linq;
using UnityEngine;



public class GateTrigger : MonoBehaviour
{


    [SerializeField]
    public bool isOnTrigger;
    [SerializeField]
    public bool isSwitchedOn;
    [SerializeField]
    private GateController[] gate;



    [SerializeField]
    public Player player;
    
    Animator anim;


        void Start()
        {
            anim = GetComponentInChildren<Animator>();
        }

        void OnTriggerEnter(Collider other)
        {
            player = GameObject.FindGameObjectWithTag("Player_2D").GetComponent<Player>();

            if(other.CompareTag("Player_2D"))
            {
            isOnTrigger = true;
            player.gateTrigger = this;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player_2D"))
            {
            isOnTrigger = false;
            player.gateTrigger = null;
            }
        }


    //initialized by Player.cs
    public void Action()
    {
        if(isSwitchedOn)
        {
            anim.SetBool("TriggerSwitcherOn", true);
            
            for(int i = 0; i < gate.Length; i++)
            {
            gate[i].isSwitchedOn = !gate[i].isSwitchedOn;
            gate[i].UpdateStatus();
            }

        }
        
        else
        {
            anim.SetBool("TriggerSwitcherOn", false);
            
            for(int i = 0; i < gate.Length; i++)
            {
            gate[i].isSwitchedOn = !gate[i].isSwitchedOn;
            gate[i].UpdateStatus();
            }
        }
    }

}