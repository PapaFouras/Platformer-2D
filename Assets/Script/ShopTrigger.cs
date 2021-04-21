using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    private Text interactUI;

    public string PNJname;
    public Item[] itemToSell;

    private void Start() {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    public bool isInRange;
    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.J)){
           ShopManager.instance.OpenShop(itemToSell, PNJname);
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
            ShopManager.instance.CloseShop();        
            }

        
    }

}
