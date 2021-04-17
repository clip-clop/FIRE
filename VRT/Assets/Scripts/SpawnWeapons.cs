using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapons : MonoBehaviour
{
    public GameObject[] WeaponPieces;
    public Transform[] P123;
   
   
    public void SpawnModel()
    {
       Instantiate(WeaponPieces[0], P123[0].position, P123[0].rotation);
       Instantiate(WeaponPieces[1], P123[1].position, P123[1].rotation);
       Instantiate(WeaponPieces[2], P123[2].position, P123[2].rotation);
    }
}
