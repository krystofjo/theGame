using System;
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
            player = GameObject.FindGameObjectWithTag("Player_2D").GetComponent<Player>();

            if(other.CompareTag("Player_2D"))
            {
            isOnTrigger = true;
            player.segmentTrigger = this;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player_2D"))
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
                segment[i].isSwitchedOn = !segment[i].isSwitchedOn;
                segment[i].UpdateStatus();
            }
        }
        
        else
        {
            anim.SetBool("TriggerSwitcherOn", false);
            
            for(int i = 0; i < segment.Length; i++)
            {
            segment[i].isSwitchedOn = !segment[i].isSwitchedOn;;
            segment[i].UpdateStatus();
            }
        }
    }

}