using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfMainDetale : MonoBehaviour
{
    public int indexOfPoint;//индекс точки, для проверки 
    public string nameOfDetale;
    public GameObject mainDetale;//главная деталь 

    public int chainOfConnection;//показывает на какой сейчас стадии скрепление
    public GameObject[] pointsPosition;//кординатные точки при скреплении  

    public PointsOfMainDetale pointsOfMainDetale;
    

   
    void Update()
    {
        if(indexOfPoint != 1)
        {
            chainOfConnection = pointsOfMainDetale.chainOfConnection;
        }
    }
}
