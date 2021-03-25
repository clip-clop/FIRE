using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UnBonding : MonoBehaviour
{
    RaycastHit hit;

    public string ba;
 
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.right * 2f);
        
        
        Physics.Raycast(transform.position,Vector3.right * 2f,out hit);
        if (hit.collider != null && hit.collider.isTrigger == true)
        {
            try
            {
                ba = hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger.ToString();
                hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }
        }
        
            
    }
}
