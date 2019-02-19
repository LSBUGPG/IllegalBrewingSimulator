using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class Playbutton : MonoBehaviour
    {

        // Use this for initialization
        public void PlayGame()
        {
        SceneManager.LoadScene("Just Incase");
        }

    public void QuitGame ()
    {
        Application.Quit();
    }
    }
