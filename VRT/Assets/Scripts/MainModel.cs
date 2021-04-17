using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MainModel : MonoBehaviour
{
    public bool WholeModel;
    public bool[] scoreOfbondig;
    
    public Interactable interactable;
    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }
    void Update()
    {
        if((scoreOfbondig[0] && scoreOfbondig[1]) == true)
        {
             WholeModel = true;
        }
        else if(scoreOfbondig[0] == false || scoreOfbondig[1] == false)
        {
            WholeModel = false;
        }
        if(interactable.attachedToHand != null)
        {
            GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            GetComponent<MeshCollider>().enabled = true;
        }
    }
    
}
