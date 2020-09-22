using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftNotice : MonoBehaviour
{
        [SerializeField]
    public Player player;
    GameObject notice;


    void Start()
    {
            notice = this.transform.Find("Notice").gameObject;
            notice.SetActive(false);
        
    }

    void OnTriggerEnter(Collider other)
        {
            player = GameObject.FindGameObjectWithTag("Player_2D").GetComponent<Player>();

            if(other.CompareTag("Player_2D"))
            {
            notice.SetActive(true);
            }
        }

            void OnTriggerExit(Collider other)
        {
            if(other.CompareTag("Player_2D"))
            {
            notice.SetActive(false);
            }
        }

}


