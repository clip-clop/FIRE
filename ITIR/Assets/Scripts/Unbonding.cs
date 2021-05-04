using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Unbonding : MonoBehaviour
{
    public Interactable interactable;
    public PartsOption partsOption;
    public Bonding bonding;
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

   
    void Update()
    {
        if(interactable.attachedToHand != null)
        {
            bonding.bonding.partsOption.pointsConnector[0] = false;
            bonding.bonding.partsOption.pointsConnector[1] = false;
        }
    }
}
