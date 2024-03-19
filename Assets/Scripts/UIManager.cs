using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text currentHP;
    [SerializeField] TMP_Text currentDay;


   [SerializeField] GameObject Player;


    void Start()
    {

    }

    void Update()
    {
        currentHP.text = Player.GetComponent<PlayerHealth>().GetHealth().ToString();

        currentDay.text = "Day " + GameManagerScript.instance.GetDayCount().ToString();
    }
}
