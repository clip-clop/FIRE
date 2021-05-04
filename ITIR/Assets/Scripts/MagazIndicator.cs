using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class MagazIndicator : MonoBehaviour
{
    public Text bulletsIndicatorOfMagaz;
    public int bulletsCountOfMagaz;
    public Bonding bonding;
    public FireAction fireAction;
    public bool transmissionBullets;
    public bool wasBondedHere;//проверка: была ли произведена передача данных 
    Interactable interactable;
    void Start()
    {
        interactable = GetComponent<Interactable>();
        wasBondedHere = false;
        transmissionBullets = false;
    }
    void Update()
    {
        bulletsIndicatorOfMagaz.text = bulletsCountOfMagaz.ToString();
        if (bonding.partsOption.wasBonded == false)
        {
            if (interactable.attachedToHand != null)
            {
                bulletsIndicatorOfMagaz.enabled = true;
            }
            else if (interactable.attachedToHand == null)
            {
                bulletsIndicatorOfMagaz.enabled = false;
            }
        }
        else if(bonding.partsOption.wasBonded == true)
        {
            bulletsIndicatorOfMagaz.enabled = false;
        }

        if(bonding.partsOption.wasBonded == true && transmissionBullets == false)
        {
            fireAction = bonding.pointsOfMainDetale.mainDetale.GetComponent<FireAction>();
            fireAction.bulletsCount = bulletsCountOfMagaz;
            bulletsCountOfMagaz = 0;
            transmissionBullets = true;
            wasBondedHere = true;

        }
        else if(bonding.partsOption.wasBonded == false && wasBondedHere == true)
        {
            bulletsCountOfMagaz = fireAction.bulletsCount;
            if(fireAction != null)
            {
                fireAction.bulletsCount = 0;
                fireAction = null;
            }
            wasBondedHere = false;
        }

        if(bonding.partsOption.wasBonded == false)
        {
            transmissionBullets = false;
        }
    }
}
