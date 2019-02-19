using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public static bool GameIsOver = false;
    public GameObject GameOver;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (GameIsOver)
            {
                Menu();
            }
            else
            {
                Quit();
            }
        }
    }

   public void Menu()
{
     GameOver.SetActive(false);
    Time.timeScale = 1f;
    GameIsOver = false;

}
    void Quit()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
