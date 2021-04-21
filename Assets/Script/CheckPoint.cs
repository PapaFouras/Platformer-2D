using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{


    private Animator flagSystem;
    public GameObject graphics;

    
    private void Awake() {
        flagSystem = graphics.GetComponent<Animator>();

    }
  private void OnTriggerEnter2D(Collider2D collision) {
      if(collision.CompareTag("Player")){
          CurrentSceneManager.instance.respawnPoint = transform.position;
          gameObject.GetComponent<BoxCollider2D>().enabled = false;
          StartCoroutine(FlagRises());
        }
    }
        public IEnumerator FlagRises(){
        flagSystem.SetTrigger("FlagRise");
        yield return new WaitForSeconds(1f);
        }

}







