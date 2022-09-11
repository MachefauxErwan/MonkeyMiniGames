using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPanel : MonoBehaviour
{
    [SerializeField]
    private List<MonkeyData> content = new List<MonkeyData>();

    [SerializeField]
    private GameObject monkeyPanel;

    [SerializeField]
    private Transform monkeySlotParent;

    [SerializeField]
    private GameObject monkeySlotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        onConfigure();
    }


    void onConfigure()
    {
        for (int i = 0; i < content.Count; i++)
        {
            // Récupère les elemenets nécessaires pour cette recette
            GameObject monkeySlot = Instantiate(monkeySlotPrefab, monkeySlotParent);
            MonkeySlot currentSlot = monkeySlot.GetComponent<MonkeySlot>();
            currentSlot.monkeyData = content[i];
            currentSlot.visualIcone.sprite = content[i].visualIcone;
        }
    }

}
