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

        void Start()
        {
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
        gate.isSwitchedOn = true;
        gate.UpdateStatus();
        }
        
        else
        {
        gate.isSwitchedOn = false;
        gate.UpdateStatus();
        }
    }

}