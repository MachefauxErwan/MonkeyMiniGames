using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPlayerUI : MonoBehaviour
{
   // [HideInInspector]
    public bool isReady = false;

    [SerializeField]
    private Image readyImage;

    [SerializeField]
    private Text readyButton;
 
    public GameObject monkeySpawner;


    public void ReadyButton()
    {

        if(isReady)
        {
            isReady = false;
        }
        else
        {
            isReady = true;
        }
        readyImage.gameObject.SetActive(isReady);
        readyButton.text = isReady == true ? "Ready" : "Not Ready";
        
    }

}
