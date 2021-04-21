using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private Text interactUI;

    private void Start() {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    public bool isInRange;
    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.J)){
           TriggerDialogue();
        }        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player")){
            isInRange = true;
            interactUI.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {

        
        if(other.CompareTag("Player")){
            isInRange = false;
            interactUI.enabled = false;
            DialogueManager.instance.EndDialogue();        }

        
    }

    void TriggerDialogue(){
        DialogueManager.instance.StartDialogue(dialogue);
    }

}
