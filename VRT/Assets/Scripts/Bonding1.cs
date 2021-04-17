using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System;

public class Bonding1 : MonoBehaviour
{
    
    public WeaponsIndex weaponsIndex;

    public Transform transformsPointInWIndex; //узнаем положение точки на оружии 
    public bool isbonding; //проверка  произошло ли сцепление объектов 
    public bool wasConnected;


    public Interactable interactable;//проверка по взаимодействие с объектом 

    public string ShowTag; //просто показывает тег у главной детали

    public int indexOfPiece;//индекс кусочка 
    public GameObject himModel; //модель которая принадлежит к точке скрепления 
    private void Start()
    {
        wasConnected = false;
        interactable = himModel.GetComponent<Interactable>();
    }
    private void Update()
    {
        if (isbonding == true)
        {
            if(weaponsIndex != null)
            transformsPointInWIndex = weaponsIndex.transformsPoint;

            himModel.transform.position = transformsPointInWIndex.position;
            himModel.transform.rotation = transformsPointInWIndex.rotation;
        }
        else if (isbonding == false)
        {
            himModel.transform.position = himModel.transform.position;
            himModel.transform.rotation = himModel.transform.rotation;
          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<WeaponsIndex>() != null && isbonding == false)
        {
             if( other.gameObject.GetComponent<WeaponsIndex>().weaponsTag.tag == "M9" && other.gameObject.tag == "Bond")
             {
                 weaponsIndex = other.gameObject.GetComponent<WeaponsIndex>();
                 if (other.gameObject.name == indexOfPiece.ToString() && interactable.attachedToHand != null)
                 {
                     bond();
                 }
             }

        }
      
         
         
        
    }
    public void bond()
    {
        isbonding = true;
        interactable.attachedToHand = null;
        weaponsIndex.weaponsTag.GetComponent<MainModel>().scoreOfbondig[indexOfPiece - 1] = true;
        wasConnected = true;
    }
}
