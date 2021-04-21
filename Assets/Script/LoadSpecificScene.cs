using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadSpecificScene : MonoBehaviour
{

    private Animator fadeSystem;

    public string sceneName;

    private void Awake() {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            StartCoroutine(loadNextScene());
            
        }
    }

    public IEnumerator loadNextScene(){

        LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
 
}
