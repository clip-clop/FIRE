using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magaz : MonoBehaviour
{
    public Bonding1 bonding1;
    public int bulletcount;
    public Text textShowbulletByMagaz;
    public bool transmissionData;
    public bool catchData;
    [SerializeField]
    bool wasConnected;
    private void Start()
    {
        wasConnected = false;
        transmissionData = false;
        catchData = false;
    }
    private void Update()
    {
        textShowbulletByMagaz.text = bulletcount.ToString();
        if (bonding1.isbonding == true  || bonding1.interactable.attachedToHand == null)
        {
            textShowbulletByMagaz.enabled = false;
            if(bonding1.isbonding == true && transmissionData == false)
            {
                wasConnected = true;
                bonding1.weaponsIndex.weaponsTag.GetComponent<FireActions>().bulletCountOnMainbody = bulletcount;
                transmissionData = true;
            }
        }
        else if (bonding1.isbonding == false || bonding1.interactable.attachedToHand != null)
        {
            textShowbulletByMagaz.enabled = true;
            if(bonding1.isbonding == false && bonding1.weaponsIndex != null && wasConnected == true)
            {
                wasConnected = false;
                catchData = true;
                if(catchData == true)
                {
                    bulletcount = bonding1.weaponsIndex.weaponsTag.GetComponent<FireActions>().bulletCountOnMainbody;
                    catchData = false;
                }
                StartCoroutine(ResettingBulletCountData());
                transmissionData = false;
            }
        }
    }
    IEnumerator ResettingBulletCountData()
    {
        yield return new WaitForSeconds(0.01f);  
        if(bonding1.weaponsIndex != null)
        bonding1.weaponsIndex.weaponsTag.GetComponent<FireActions>().bulletCountOnMainbody = 0;

        bonding1.weaponsIndex = null;
    }
}
