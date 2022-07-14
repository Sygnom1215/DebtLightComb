using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    [SerializeField]
    private GameObject waitPanel;

    private bool isFade;
    private void Start()
    {
        waitPanel.SetActive(false);
        isFade = false;
    }
    public void PotalClick()
    {
        if(isFade==false)
        {
            waitPanel.SetActive(true);
            isFade = true;
        }
        else if(isFade==true)
        {
            waitPanel.SetActive(false);
            isFade = false;
        }
    }

}
