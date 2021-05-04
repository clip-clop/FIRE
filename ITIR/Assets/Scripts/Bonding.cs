using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonding : MonoBehaviour
{

    public GameObject partsPosition;//кордината, которая будет присвоена детале при скреплении
    public int partsIndex;//индекс части 
    public GameObject Detale;//деталь, к которой принадлежат точки 
    public int indexOfPointsPosition;//индекс для partsPosition

    public PointsOfMainDetale pointsOfMainDetale;
    public Bonding bonding;

    public PartsOption partsOption;
    public string nameOfConnectorsPoint;
    public string nameOfMainDetale;
    private void Start()
    {
        partsOption.wasBonded = false;
    }
    void Update()
    {

        if (partsIndex != 1)
        {
            pointsOfMainDetale = bonding.pointsOfMainDetale;
            partsOption = bonding.partsOption;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (bonding.partsOption.wasBonded != true)
        {
            if (partsIndex == 1)
            {
                if (other.gameObject.GetComponent<PointsOfMainDetale>() != null)
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == bonding.nameOfMainDetale)
                    {
                        if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == bonding.nameOfConnectorsPoint && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 2 && bonding.pointsOfMainDetale != null)
                        {

                            if (bonding.pointsOfMainDetale.chainOfConnection == 2)
                            {
                                bonding.pointsOfMainDetale.chainOfConnection = 0;
                                bonding.partsOption.pointsConnector[1] = false;
                                bonding.partsOption.pointsConnector[0] = false;
                                bonding.partsPosition = null;
                                bonding.pointsOfMainDetale = null;
                            }
                        }
                    }
                }
            }
            else if (partsIndex == 2)
            {
                if (other.gameObject.GetComponent<PointsOfMainDetale>() != null)
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == bonding.nameOfMainDetale)
                    {
                        if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == bonding.nameOfConnectorsPoint && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                        {
                            if (bonding.pointsOfMainDetale != null)
                            {
                                if (bonding.partsOption.pointsConnector[0] == true)
                                {
                                    bonding.pointsOfMainDetale.chainOfConnection = 0;
                                    bonding.partsOption.pointsConnector[1] = false;
                                    bonding.partsOption.pointsConnector[0] = false;
                                    bonding.partsPosition = null;
                                    bonding.pointsOfMainDetale = null;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (bonding.partsOption.wasBonded != true)
        {
            if (partsIndex == 1)
            {
                if (other.gameObject.GetComponent<PointsOfMainDetale>() != null)
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == bonding.nameOfMainDetale)
                    {
                        if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == bonding.nameOfConnectorsPoint && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                        {
                            bonding.pointsOfMainDetale = other.gameObject.GetComponent<PointsOfMainDetale>();
                            if (bonding.pointsOfMainDetale.chainOfConnection == 0)
                            {
                                bonding.pointsOfMainDetale.chainOfConnection = 1;
                            }
                        }
                        else if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == bonding.nameOfConnectorsPoint && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 2 && bonding.pointsOfMainDetale.chainOfConnection == 1)
                        {
                            bonding.pointsOfMainDetale.chainOfConnection = 2;
                            bonding.partsOption.pointsConnector[0] = true;
                            bonding.partsPosition = bonding.pointsOfMainDetale.pointsPosition[bonding.indexOfPointsPosition];
                        }
                    }
                }
            }
            else if (partsIndex == 2)
            {

                if (other.gameObject.GetComponent<PointsOfMainDetale>() != null)
                {
                    if (other.gameObject.GetComponent<PointsOfMainDetale>().mainDetale.tag == bonding.nameOfMainDetale)
                    {
                        if (other.gameObject.GetComponent<PointsOfMainDetale>().nameOfDetale == bonding.nameOfConnectorsPoint && other.gameObject.GetComponent<PointsOfMainDetale>().indexOfPoint == 1)
                        {
                            if (bonding.partsOption.pointsConnector[0] == true)
                            {
                                bonding.partsOption.pointsConnector[1] = true;
                            }
                        }
                    }
                }

            }
        }
    }
}
