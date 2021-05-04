using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyOfWeapon : MonoBehaviour
{
    public bool[] checkOfConnecting;
    public bool wholeModel;
    private void Update()
    {
        for(int i = 0;i < checkOfConnecting.Length; i++)
        {
            if(checkOfConnecting[i] == true)
            {
                wholeModel = true;
            }
            else if(checkOfConnecting[i] == false)
            {
                wholeModel = false;
                break;
            }
        }

    }
}
