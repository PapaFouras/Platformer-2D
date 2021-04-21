using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ladder : MonoBehaviour
{
    private bool isInRange = false;
    private PlayerMovement playerMovement;
    public BoxCollider2D ladderCollider;

    private Text interactUI;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.J)){

            //descente de l'échelle
            playerMovement.isClimbing = false;
            ladderCollider.isTrigger = false;

            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.J)){
                playerMovement.isClimbing = true;
                ladderCollider.isTrigger = true;
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

            interactUI.enabled = false;
            isInRange = false;
            playerMovement.isClimbing = false;
            ladderCollider.isTrigger = false;

        }
    }
}
