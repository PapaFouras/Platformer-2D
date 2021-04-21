using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public int coinsToAdd = 10;
public Animator animator;

public AudioClip soundToPlay;

private void Awake() {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && isInRange){
            OpenChest();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            interactUI.enabled = false;
            isInRange = false;

        }
    }

    void OpenChest(){
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay,transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;

    }
}
