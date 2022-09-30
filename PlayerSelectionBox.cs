using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelectionBox : MonoBehaviour
{
    [SerializeField]
    private Transform CanvaPlayerParent1;
    [SerializeField]
    private Transform CanvaPlayerParent2;
    [SerializeField]
    private Transform CanvaPlayerParent3;
    [SerializeField]
    private Transform CanvaPlayerParent4;

    [SerializeField]
    private GameObject monkeyPlayerPrefab;

    [SerializeField]
    private Text playerCountUI;
    
    private int nbPlayer = 1;
    private int currentPlayerID = 1;
    private List<MonkeyData> contentMonkeyChoosed = new List<MonkeyData>();

    [SerializeField]
    private Button readyStartButton;
    
    private void Update()
    {
        readyStartButton.interactable = VerifyReadyToPlay();
    }

    private bool VerifyReadyToPlay()
    {
        Transform[] CanvaPlayers = { CanvaPlayerParent1, CanvaPlayerParent2, CanvaPlayerParent3, CanvaPlayerParent4 };

        for (int i = 0; i < nbPlayer; i++)
        {
            if (CanvaPlayers[i].childCount > 0)
            {
                if (!(CanvaPlayers[i].GetChild(0).GetComponent<ConfigPlayerUI>().isReady))
                {
                    return false;
                }
            }
            else return false;
        }
        return true;
    }

    public void ChooseMonkey(MonkeyData monkeyData)
    {
        if(MaximumPlayerNotReached())
        {
            AddMonkey(monkeyData);
        }
        else
        {
            //ChangeMonkey(monkeyData, currentPlayerID);
            Debug.Log(" Maximum player reached ");
        }
        UpdateCurrentPlayerID();
    }

    private void UpdateCurrentPlayerID()
    {
        if(currentPlayerID < contentMonkeyChoosed.Count)
        {
            currentPlayerID ++ ;
        }
        else 
        {
            currentPlayerID = 1;
        }
    }

    private bool MaximumPlayerNotReached()
    {
        return (contentMonkeyChoosed.Count < nbPlayer);
    }

    public void OnIncreaseButton()
    {
        if(nbPlayer < 4)
        {
            nbPlayer++;
        }
        UpdatePlayerCountUI(nbPlayer);
       
    }
    public void OnDecreaseButton()
    {
        if (nbPlayer > 1)
        {
            nbPlayer--;
           RemoveMonkey(contentMonkeyChoosed[nbPlayer]);
        }
        UpdatePlayerCountUI(nbPlayer);
        
    }

    private void UpdatePlayerCountUI(int count)
    {
        playerCountUI.text = count.ToString();
    }

    private void RemoveMonkey(MonkeyData monkeyData)
    {
        contentMonkeyChoosed.Remove(monkeyData);

        RefreshContent();
    }
    private void AddMonkey(MonkeyData monkeyData)
    {
        contentMonkeyChoosed.Add(monkeyData);
        RefreshContent();
    }

    private void ChangeMonkey(MonkeyData monkeyData, int playerID)
    {
        contentMonkeyChoosed[playerID-1] = monkeyData;
        RefreshContent();
    }

 

    private void RefreshContent()
    {
        Transform[] CanvaPlayers = { CanvaPlayerParent1, CanvaPlayerParent2, CanvaPlayerParent3, CanvaPlayerParent4 };       
       
        //on efface tout les canvas
        for (int i = 0; i < CanvaPlayers.Length; i++)
        {
            if(CanvaPlayers[i].childCount > 0)
            {
                Destroy(CanvaPlayers[i].GetChild(0).gameObject);
            }
        }

        //on repeuple les canvas
        for (int i = 0; i < contentMonkeyChoosed.Count; i++)
        {
            //GameObject monkeyPlayer = Instantiate(contentMonkeyChoosed[i].prefabUIVisuel3D, CanvaPlayers[i]);
            GameObject canvasMonkeyPlayer = Instantiate(monkeyPlayerPrefab, CanvaPlayers[i]);
            ConfigPlayerUI monkeyConfigPlayer = canvasMonkeyPlayer.GetComponent<ConfigPlayerUI>();

            GameObject monkeyPlayer  =  Instantiate(contentMonkeyChoosed[i].prefab3D, monkeyConfigPlayer.monkeySpawner.transform) ;
            PlayerController playerController =  monkeyPlayer.GetComponent<PlayerController>();
            playerController.StartToDance();
        }
    }

    public void StartButton()
    {
        
        PlayerPrefs.SetInt("NbPlayer", nbPlayer);
        for (int i = 0; i < nbPlayer; i++)
        {
            PlayerPrefs.SetString("Player"+i, contentMonkeyChoosed[i].name);

        }
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");


        SceneManager.LoadScene("BomberMiniGame");

    }

   

}


