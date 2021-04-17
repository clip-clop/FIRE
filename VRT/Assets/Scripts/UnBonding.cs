using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UnBonding : MonoBehaviour
{
    Bonding1 bonding1;
   
    private void Start()
    {
        bonding1 = GetComponent<Bonding1>();
    }
    void Update()
    {
       if(bonding1.interactable.attachedToHand != null && bonding1.weaponsIndex != null)
       {
            bonding1.weaponsIndex.weaponsTag.GetComponent<MainModel>().scoreOfbondig[bonding1.indexOfPiece - 1] = false;
            bonding1.isbonding = false;
       }
      
    }

}
