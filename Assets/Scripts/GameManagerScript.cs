using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    float gameTimer = 0;
    int dayCount;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dayCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer > 30)
        {
            dayCount++;

            if (dayCount > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", dayCount);
                PlayerPrefs.Save();
            }


            gameTimer = 0;
        }
    }


    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        dayCount = 0;
    }

    public int GetDayCount()
    {
        return dayCount;
    }
}
