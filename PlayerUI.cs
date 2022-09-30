using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public MonkeyData monkeyData;
    public Image MonkeyIcone;
    public Text PlayerName;
    public Image PanelColorMonkey;
    public Image PanelAddictionalColorMonkey;


    [SerializeField]
    private Text AddictionalUIScoreText;
    [SerializeField]
    private Text UIScoreText;



    public void setAdditionalPoints(int points)
    {
        AddictionalUIScoreText.text = points.ToString("000#");
       

    }
    public int getPoints()
    {
        return int.Parse(UIScoreText.text);
    }
    public int getAdditionalPoints()
    {
        return int.Parse(AddictionalUIScoreText.text);
    }
    public void setPoints(int points)
    {
        UIScoreText.text = ""+ points.ToString("000#");

        

    }
    public void setPoints()
    {
        UIScoreText.text = AddictionalUIScoreText.text;
    }



}
