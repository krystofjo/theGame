using System;
using System.Linq;
using UnityEngine;



public class Trigger : MonoBehaviour
{


    [SerializeField]
    public bool isOnTrigger;
    [SerializeField]
    public bool isSwitchedOn;
    [SerializeField]
    private GateController gate;


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
            player.trigger = this;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Character"))
            {
            isOnTrigger = false;
            player.trigger = null;
            }
        }

    void Update()
    {

    } 

    public void Action()
    {
        if(isSwitchedOn)
        {
            anim.SetBool("TriggerSwitcherOn", true);
            gate.isSwitchedOn = true;
            gate.UpdateStatus();
        }
        
        else
        {
            anim.SetBool("TriggerSwitcherOn", false);
            gate.isSwitchedOn = false;
            gate.UpdateStatus();
        }
    }

}