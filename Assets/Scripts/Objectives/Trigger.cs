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


    public Player player;

        void Start()
        {
        player = GameObject.FindGameObjectWithTag("Character").GetComponent<Player>();
        }

        void OnTriggerEnter(Collider other)
        {
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

        if(Input.GetKeyDown(KeyCode.LeftShift) && isOnTrigger)
        {
            Debug.Log("KeyPressed");
            isSwitchedOn = !isSwitchedOn;
            Action();
        }

    } 

    void Action()
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