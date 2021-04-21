
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credit : MonoBehaviour
{
   private void LoadMainMenu(){
       SceneManager.LoadScene("MainMenu");
   }


   private void Update() {
       if(Input.GetKeyDown(KeyCode.Escape))
           SceneManager.LoadScene("MainMenu");

   }
}
