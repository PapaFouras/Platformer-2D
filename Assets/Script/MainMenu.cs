
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

public GameObject settingsWindow ;
    public string levelToLoad;

    public void StartGame(){

        SceneManager.LoadScene(levelToLoad);

        


    }

    public void SettingsButton(){
        settingsWindow.SetActive(true);
        
    }

    public void CloseSettingsWindow(){
        settingsWindow.SetActive(false);
    }
    public void QuitGame(){

        Application.Quit();
        
    }

}
