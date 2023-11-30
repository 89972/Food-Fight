using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine.Events;
using System.Threading;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class PlayerController : Entity
{
    public Hand hand;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");
    private Animator animator;
    private Camera mainCamera;

    public static PlayerController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Update()
    {
     if(grabGripAction.GetStateDown(handType))
        {
            SpawnObjectInHand();
        }
    }

    private void SpawnObjectInHand()
    {
        //take a random fruit from a foodstand
        GameObject fruit = Instantiate(GameManager.Instance.fruits[(int)currentFruit].prefab, transform.position, Quaternion.identity);
        hand.AttachObject(fruit, GrabTypes.Grip);
        
    }
}

