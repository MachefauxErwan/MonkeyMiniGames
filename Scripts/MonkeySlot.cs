using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonkeySlot : MonoBehaviour
{
    public MonkeyData monkeyData;
    public Image visualIcone;
  
    [SerializeField]
    private MonkeyActionsSystem monkeyActionsSystem;
    private void Awake()
    {
        monkeyActionsSystem = GameObject.Find("GameManager").GetComponent<MonkeyActionsSystem>();
    }


    public void ClickOnSlot()
    {

        //Debug.Log("tu as cliquer sur " + monkeyData.MonkeyName);
        
        monkeyActionsSystem.ChooseMonkey(monkeyData);
    }
}
