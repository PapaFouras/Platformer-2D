using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject settingsMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }
            else{
                Paused();
            }
        }
        
    }

    public void Paused(){

    PlayerMovement.instance.enabled = false;
        //afficher menu pause
    pauseMenuUI.SetActive(true);
        //arreter le temps
    Time.timeScale = 0;
        //Changer le statut du jeu
    gameIsPaused = true;
    }

    public void SettingsButton(){

settingsMenuUI.SetActive(true);

    }

    public void QuitSettingsButton(){
settingsMenuUI.SetActive(false);

    }

    public void Resume(){
        

    PlayerMovement.instance.enabled = true;

    pauseMenuUI.SetActive(false);
        //arreter le temps
    Time.timeScale = 1;
        //Changer le statut du jeu
    gameIsPaused = false;
    }

    public void LoadMainMenu(){
        Resume();
SceneManager.LoadScene("MainMenu");
    }
}
