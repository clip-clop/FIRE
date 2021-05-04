using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class FireAction : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAct;
    public Animation anim;
    public AudioSource[] audioSource;
    public Transform FirePoint;
    public int bulletsCount;
    public Text bulletsIndicator;
    public RaycastHit raycastHit;
    Interactable interactable;
    BodyOfWeapon bodyOfWeapon;
    void Start()
    {
        bodyOfWeapon = GetComponent<BodyOfWeapon>();
        audioSource[0] = GetComponent<AudioSource>();
        interactable = GetComponent<Interactable>();
    }

    
    void Update()
    {
        Debug.DrawRay(FirePoint.position, FirePoint.right * -100);
        bulletsIndicator.text = bulletsCount.ToString();
        if(interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAct[source].stateDown)
            {
                if (bulletsCount > 0 && bodyOfWeapon.wholeModel == true)
                {
                    Fire();
                    if (raycastHit.collider != null)
                    {
                        Debug.Log(raycastHit.collider.gameObject.name);
                        if (raycastHit.collider.gameObject.tag == "Target")
                        {
                            raycastHit.collider.gameObject.GetComponent<AudioSource>().Play();
                            raycastHit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                        }
                    }
                }
                else if (bulletsCount <= 0 && bodyOfWeapon.wholeModel == true)
                {
                    NoneAmmo();
                }
            }
        }
      
    }
    void Fire()
    {
        Debug.Log("FIRE");
        anim.Play();
        Physics.Raycast(FirePoint.position, FirePoint.right * -100, out raycastHit);
        bulletsCount--;
        audioSource[0].Play();
    }
    void NoneAmmo()
    {
        audioSource[1].Play();
    }
}
