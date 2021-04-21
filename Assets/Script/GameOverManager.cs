
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

public GameObject gameOverUI;

public static GameOverManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }
        instance = this;
    
    }
  
public void OnPlayerDeath(){
    gameOverUI.SetActive(true);
}


public void RetryButton(){

    //Recommencer le niveau
    Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    PlayerHealth.instance.Respawn();

    //recharger la scene

    //replacer le joeuur au spawn

    // reactive les mouvements du joueur + lui rendre sa vie

    gameOverUI.SetActive(false);

}

public void MainMenuButton(){


    SceneManager.LoadScene("MainMenu");

}

public void QuitButton(){

    //Fermer le jeu
    Application.Quit();
}


}
