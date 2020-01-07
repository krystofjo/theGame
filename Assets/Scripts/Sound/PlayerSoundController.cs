﻿using UnityEngine;
using FMODUnity;


[RequireComponent(typeof(Player))]
public class PlayerSoundController : MonoBehaviour
{
    const string speedParam = "Speed";

    [SerializeField]
    [EventRef]
    string movementEventRef;
    [SerializeField]
    [EventRef]
    string jumpEventRef;
    [SerializeField]
    [EventRef]
    string landEventRef;

    Player player;
    
    FMOD.Studio.EventInstance movementEvent;


    void Start()
    {
        player = GetComponent<Player>();

        player.onMove += OnMove;
        player.onJump += OnJump;
        player.onLand += OnLand;

        movementEvent = RuntimeManager.CreateInstance(movementEventRef);
        movementEvent.start();
    }

    void OnDestroy()
    {
        movementEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        player.onMove -= OnMove;
        player.onJump -= OnJump;
        player.onLand -= OnLand;
    }

    void OnMove(float dist)
    {
        movementEvent.set3DAttributes(RuntimeUtils.To3DAttributes(transform));

        movementEvent.setParameterByName(speedParam, dist);
    }

    void OnJump()
    {
        RuntimeManager.PlayOneShot(jumpEventRef, transform.position);
    }

    void OnLand()
    {
        RuntimeManager.PlayOneShot(landEventRef, transform.position);
    }
}