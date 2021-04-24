using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsOption : MonoBehaviour
{
    public Bonding bonding;
    Rigidbody Irigidbody;
    private void Start()
    {
        Irigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(bonding.wasBonded == true)
        {
            Irigidbody.isKinematic = true;
            transform.position = bonding.partsPosition.transform.position;
            transform.rotation = bonding.partsPosition.transform.rotation;
            
        }
    }
}
