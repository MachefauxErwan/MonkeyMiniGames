using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyPlayersUI : MonoBehaviour
{

    [SerializeField]
    private List<MonkeyData> monkeyLibrairies = new List<MonkeyData>();

    [SerializeField]
    private GameObject PlayerUIPrefab;

    [SerializeField]
    private Transform PlayersUIParent;

    [SerializeField]
    private Transform Spawner;

    [SerializeField]
    private List<MonkeyData> content = new List<MonkeyData>();

    void onInitUIPlayer()
    {
        int nbPlayer = PlayerPrefs.GetInt("NbPlayer");
        for (int i = 0; i < nbPlayer; i++)
        {
            GameObject monkeySlot = Instantiate(PlayerUIPrefab, PlayersUIParent);

            PlayerUI currentplayer = monkeySlot.GetComponent<PlayerUI>();
            string player = PlayerPrefs.GetString("Player" + i);
            for (int j = 0; j < monkeyLibrairies.Count; j++)
            {
                if(monkeyLibrairies[j].name == player)
                {

                    content.Add(monkeyLibrairies[j]);
                    currentplayer.MonkeyIcone.sprite = monkeyLibrairies[j].visualIcone;
                    currentplayer.PlayerName.text = monkeyLibrairies[j].name;
                    break;
                }
            }   
            
    

        }
       
    }

    // Start is called before the first frame update
   private void Awake()
    {
        onInitUIPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
