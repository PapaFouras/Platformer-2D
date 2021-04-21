using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Item item;

public AudioClip soundToPlay;

private void Awake() {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && isInRange){
            TakeItem();
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

    void TakeItem(){
       Inventory.instance.content.Add(item);
       Inventory.instance.UpdateInventoryUI();
       AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
       interactUI.enabled = false;
       Destroy(gameObject);

    }
}
