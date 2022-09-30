using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonkeySlot : MonoBehaviour
{
    public MonkeyData monkeyData;
    public Image visualIcone;
  
    [SerializeField]
    private PlayerSelectionBox playerSelectionBox;
    private void Awake()
    {
        playerSelectionBox = GameObject.Find("GameManager").GetComponent<PlayerSelectionBox>();
    }


    public void ClickOnSlot()
    {

        //Debug.Log("tu as cliquer sur " + monkeyData.MonkeyName);

        playerSelectionBox.ChooseMonkey(monkeyData);
    }
}
