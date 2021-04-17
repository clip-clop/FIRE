using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem; 
using UnityEngine.UI;

public partial class FireActions : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAct;
    MainModel mainModel;
    public Transform FirePoint;
    RaycastHit Hit;
    public MeshRenderer mR;

    public Text textShowbullet;
    public int bulletCountOnMainbody;

    public Interactable interactable;
    
    void Start()
    {
        mainModel = GetComponent<MainModel>();
        interactable = GetComponent<Interactable>();
        
    }
    void Update()
    {
        textShowbullet.text = bulletCountOnMainbody.ToString();
        if(mainModel.interactable.attachedToHand != null)
        {
           textShowbullet.enabled = true;
        }
        else if(mainModel.interactable.attachedToHand == null)
        {
            textShowbullet.enabled = false;
        }
        if(bulletCountOnMainbody <= 0)
        {
            bulletCountOnMainbody = 0;
        }
        if(interactable.attachedToHand != null) { 
            if((fireAct.stateDown && mainModel.WholeModel) == true && bulletCountOnMainbody > 0 && mainModel.interactable.attachedToHand != null)
            {
                Fire();
                if(Hit.collider != null && Hit.collider.tag == "Target")
                {
                    mR = Hit.collider.gameObject.GetComponent<MeshRenderer>();
                    a();
                }
            }
        }
        Debug.DrawRay(FirePoint.position, FirePoint.right * -100f);
    }
    public void Fire()
    {
        Physics.Raycast(FirePoint.position, FirePoint.right * -100f, out Hit);
        bulletCountOnMainbody--;
        
    }
    void a()
    {
        mR.material.color = Color.red;
        StartCoroutine(b());
        
    }
    IEnumerator b()
    {
        yield return new WaitForSeconds(0.1f);
        mR.material.color = Color.white;
    }
   
    
}
