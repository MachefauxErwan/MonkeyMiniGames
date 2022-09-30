using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMiniGame : MonoBehaviour
{

    [SerializeField]
    private List<MonkeyData> monkeyLibrairies = new List<MonkeyData>();

    [SerializeField]
    private GameObject PlayerUIPrefab;

    [SerializeField]
    private Transform PlayersUIParent;

    [SerializeField]
    private Transform PlayersSpawnerParent;

    [SerializeField]
    private GameObject SpawnerPrefab;
   
    private List<MonkeyData> content = new List<MonkeyData>();
    
    private List<Player> playersList = new List<Player>();
    public int playerCount;

    public static InitMiniGame instance;

    private void LoadPlayerData()
    {
        int nbPlayer = PlayerPrefs.GetInt("NbPlayer");
        for (int i = 0; i < nbPlayer; i++)
        {
            string player = PlayerPrefs.GetString("Player" + i);
            for (int j = 0; j < monkeyLibrairies.Count; j++)
            {
                if (monkeyLibrairies[j].name == player)
                {
                    content.Add(monkeyLibrairies[j]);
                    break;
                }
            }
        }
        playerCount = nbPlayer;

    }

    private void LoadPlayers()
    {
        for (int i = 0; i < content.Count; i++)
        {
            CreatePlayer(content[i]);
        }
    }
    private void CreatePlayer(MonkeyData data)
    {

        // UI
        GameObject monkeyUI = Instantiate(PlayerUIPrefab, PlayersUIParent);
        PlayerUI playerUI = monkeyUI.GetComponent<PlayerUI>();
        playerUI.PlayerName.text = data.name;
        playerUI.PanelColorMonkey.sprite = data.panelMonkey;
        playerUI.PanelAddictionalColorMonkey.sprite = data.panelMonkey;
        playerUI.MonkeyIcone.sprite = data.visualIcone;

        //SpawnerPlayers
        GameObject spawnerPlayers = Instantiate(SpawnerPrefab, PlayersSpawnerParent);

        //Prefab 3D
        GameObject playerPrefab = Instantiate(data.prefab3D, spawnerPlayers.transform);
        
        //Ajout a la liste des players
        Player player = new Player(spawnerPlayers, playerPrefab, playerUI, data);
        playersList.Add(player);
    }

    private void InitGame()
    {
        LoadPlayerData();
        LoadPlayers();
    }

    
    private void Awake()
    {
        instance = this;
        InitGame();
    }

    public List<Player> getPlayerList()
    {
        return playersList;
    }
}

public class Player
{
    public GameObject playerSpawn;
    public GameObject player;
    public PlayerUI playerUI;
    private MonkeyData data;

    public Player(GameObject playerSpawn, GameObject player, PlayerUI playerUI, MonkeyData data)
    {
        this.playerSpawn = playerSpawn;
        this.player = player;
        this.playerUI = playerUI;
        this.data = data;
    }

    public void VisualPlayer(bool enable)
    {
        player.transform.GetChild(0).gameObject.SetActive(enable);
    }

    // private MonkeyData PlayerData;
}