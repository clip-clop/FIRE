using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] GameObject HeartText;
    [SerializeField] string sText;

    void Start()
    {
        HeartText.SetActive(false);
        Text text = HeartText.GetComponent<Text>();
        text.text = sText;
    }

    public void OnMouseDown()
    {
        HeartText.SetActive(true);
    }
    public void OnMouseUp()
    {
        HeartText.SetActive(false);
    }

    public void OnMouseExit()
    {
        HeartText.SetActive(false);
    }
}