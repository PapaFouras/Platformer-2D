
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public AudioClip killSound;
    public GameObject ObjectToDetroy;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            AudioManager.instance.PlayClipAt(killSound,transform.position);
            Destroy(ObjectToDetroy);
        }
    }
}
