using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    bool isSettingsClicked = false;
    public GameObject settingsClicked;

   
    // Update is called once per frame
    void Update()
    {
        if (isSettingsClicked){
            settingsClicked.SetActive(true);
        }
        else{
            settingsClicked.SetActive(false);
        }
    }

    public void settingClicked(){
        isSettingsClicked = !isSettingsClicked;
    }
    public void goButton()
    {
        SceneManager.LoadScene("Level");
    }
    public void shopButton()
    {
        SceneManager.LoadScene("Market");
    }
}
