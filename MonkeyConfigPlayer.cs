using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyConfigPlayer : MonoBehaviour
{
   // [HideInInspector]
    public bool isReady = false;

    [SerializeField]
    private Image readyImage;

    [SerializeField]
    private Text readyButton;

    [SerializeField]
    Animator monkeyAnimator;

    [SerializeField]
    GameObject monkey3D;

    public void Awake()
    {
        int DanceLayerIndex = monkeyAnimator.GetLayerIndex("Dance Layer");
        monkeyAnimator.SetLayerWeight(DanceLayerIndex, 1f);
    }

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

    private void Update()
    {
        monkeyAnimator.SetInteger("ID_Dance", Random.Range(0, 4));
    }
}
