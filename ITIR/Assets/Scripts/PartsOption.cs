using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class PartsOption : MonoBehaviour
{
    public Bonding bonding;
   
    public bool[] pointsConnector;

    Interactable interactable;
    bool wasInteractableDisConected;

    Rigidbody Irigidbody;
    public bool wasBonded;

    public BodyOfWeapon bodyOfWeapon;
    public bool checkingWasDid;
    public bool checkingWasDidUnbonding;
    private void Start()
    {
        wasInteractableDisConected = false;
        checkingWasDidUnbonding = false;
        checkingWasDid = false;
        interactable = GetComponent<Interactable>();
        Irigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if ((pointsConnector[0] && pointsConnector[1]) == true)
           wasBonded = true;
        else if (pointsConnector[0] == false || pointsConnector[1] == false) 
           wasBonded = false;

        if(wasBonded == true)
        {
            if(wasInteractableDisConected == false)
            {
                interactable.attachedToHand = null;
                wasInteractableDisConected = true;
            }
            Irigidbody.isKinematic = true;
            transform.position = bonding.partsPosition.transform.position;
            transform.rotation = bonding.partsPosition.transform.rotation;
            bodyOfWeapon = bonding.pointsOfMainDetale.mainDetale.GetComponent<BodyOfWeapon>();
            if(checkingWasDid == false)
            {
                for (int i = 0; i < bodyOfWeapon.checkOfConnecting.Length; i++)
                {
                    if (bodyOfWeapon.checkOfConnecting[i] == true)
                    {
                        continue;
                    }
                    else if (bodyOfWeapon.checkOfConnecting[i] == false)
                    {
                        bodyOfWeapon.checkOfConnecting[i] = true;
                        break;
                    }
                }
                checkingWasDid = true;
                checkingWasDidUnbonding = false;
            }
            
        }
        else if(wasBonded == false)
        {
            if(bodyOfWeapon != null)
            {
                if (checkingWasDidUnbonding == false)
                {
                    for (int i = 0; i < bodyOfWeapon.checkOfConnecting.Length; i++)
                    {
                        if (bodyOfWeapon.checkOfConnecting[i] == false)
                        {
                            continue;
                        }
                        else if (bodyOfWeapon.checkOfConnecting[i] == true)
                        {
                            bodyOfWeapon.checkOfConnecting[i] = false;
                            break;
                        }
                    }
                    checkingWasDidUnbonding = true;
                }
            }
            wasInteractableDisConected = false;
            Irigidbody.isKinematic = false;
            checkingWasDid = false;
            bodyOfWeapon = null;
            transform.position = transform.position;
            transform.rotation = transform.rotation;
        }
       
    }
}
