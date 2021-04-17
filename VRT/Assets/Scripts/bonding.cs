using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class bonding : MonoBehaviour
{
    public WeaponsIndex WIndex;
   
    public Transform TPoint;
    public bool isbonding;
    public MeshCollider isTrig;

   
    private void Start()
    {
        isTrig = GetComponent<MeshCollider>();
    }
    private void Update()
    {
        if(isbonding == true)
        {
            transform.position = TPoint.position;
            transform.rotation = TPoint.rotation;
            isTrig.isTrigger = true;
        }
        else
        {
            transform.position = transform.position;
            transform.rotation = transform.rotation;
            isTrig.isTrigger = false;
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        WIndex = other.gameObject.GetComponent<WeaponsIndex>();
  
        try
        {
            if (WIndex.GIndex.ToString() == "M9 (UnityEngine.GameObject)")
            {
                if (other.gameObject.name == gameObject.name)
                {
                    isbonding = true;
                   
                }
            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
