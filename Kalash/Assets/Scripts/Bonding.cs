using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonding : MonoBehaviour
{
   
    public GameObject partsPosition;//кордината, которая будет присвоена детале при скреплении
    public int partsIndex;//индекс части 
    public GameObject Detale;//деталь, к которой принадлежат точки 
    public int indexOfPointsPosition;//индекс для partsPosition
    public bool wasBonded;//показывает, прикреплен ли объект
  
    public PointsOfMainDetale pointsOfMainDetale;
    public Bonding bonding;

    public string b;
    private void Start()
    {
        wasBonded = false;
    }
    void Update()
    {
       
        if(partsIndex != 1)
        {
            pointsOfMainDetale = bonding.pointsOfMainDetale;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (partsIndex == 1)
        {
            if (other.gameObject.GetComponent<PointsOfMainDetale>() != null)
            {
                if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == "M9")
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "UpperPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                    {
                        pointsOfMainDetale = other.gameObject.GetComponent<PointsOfMainDetale>();
                        if (pointsOfMainDetale.chainOfConnection == 0)
                        {
                            pointsOfMainDetale.chainOfConnection = 1;
                        }
                    }
                    else if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "UpperPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 2 && pointsOfMainDetale.chainOfConnection == 1)
                    {
                        pointsOfMainDetale.chainOfConnection = 2;
                    }
                    else if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "MagazPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                    {
                        pointsOfMainDetale = other.gameObject.GetComponent<PointsOfMainDetale>();
                        if (pointsOfMainDetale.chainOfConnection == 0)
                        {
                            pointsOfMainDetale.chainOfConnection = 1;
                        }
                    }
                    else if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "MagazPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 2 && pointsOfMainDetale.chainOfConnection == 1)
                    {
                        pointsOfMainDetale.chainOfConnection = 2;
                    }
                }
               
            }
            
        }
        else if (partsIndex == 2)
        {
            if(other.gameObject.GetComponent<PointsOfMainDetale>() != null)
            {
                if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == "M9")
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "UpperPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                    {
                        if (bonding.pointsOfMainDetale != null)
                        {
                            if (bonding.pointsOfMainDetale.chainOfConnection == 2)
                            {
                                partsPosition = pointsOfMainDetale.pointsPosition[indexOfPointsPosition];
                                wasBonded = true;
                            }
                        }
                    }
                    else if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == "MagazPoint" && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                    {
                        b = other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint.ToString();
                        if (bonding.pointsOfMainDetale != null)
                        {
                            if (bonding.pointsOfMainDetale.chainOfConnection == 2)
                            {
                                partsPosition = bonding.pointsOfMainDetale.pointsPosition[indexOfPointsPosition];
                                wasBonded = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
