using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject StatsScreen;
    [SerializeField] TMP_Text MaxDays;
    [SerializeField] TMP_Text Kills;
    [SerializeField] TMP_Text Deaths;
    [SerializeField] TMP_Text DmgDealt;
    [SerializeField] TMP_Text DmgTaken;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MaxDays.text = "Max. Days Survived : " + PlayerPrefs.GetInt("highscore").ToString();
        Kills.text = "Total Kills : " + PlayerPrefs.GetInt("kills").ToString();
        Deaths.text = "Total Deaths : " + PlayerPrefs.GetInt("nbOfDeaths").ToString();
        DmgDealt.text = "Damage Dealt : " + PlayerPrefs.GetInt("dmgDealt").ToString();
        DmgTaken.text = "Damage Taken : " + PlayerPrefs.GetFloat("dmgTaken").ToString();
    }

    public void StartButton()
    {
        GameManagerScript.instance.PlayGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenStats()
    {
        StatsScreen.SetActive(true);
    }

    public void CloseStats()
    {
        StatsScreen.SetActive(false);
    }
}
