using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    
    void Update()
    {
        if(meshRenderer.material.color == Color.red)
        {
            Invoke("NormalColor", 0.2f);
        }
    }
    void NormalColor()
    {
        meshRenderer.material.color = Color.white;
    }
}
