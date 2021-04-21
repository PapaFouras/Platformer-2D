using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{


    public Text PNJnameText;

    public Animator animator;

    public static ShopManager instance;

    public GameObject sellButtonPrefab;
    public Transform sellButtonsParent;
    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        instance = this;

    }

    public void OpenShop(Item[] items, string PNJname){
        PNJnameText.text = PNJname;
        UpdateItemsToSell(items);
        animator.SetBool("isOpen",true);

    }

    public void CloseShop(){
        //Debug.Log("fin du dialogue");
        animator.SetBool("isOpen",false);

    }

    public void UpdateItemsToSell(Item[] items){

        //supprime les potentiels boutons présents dans le parent
        for (var i = 0; i < sellButtonsParent.childCount  ; i++)
        {

            Destroy(sellButtonsParent.GetChild(i).gameObject);
        }
        //instancie une boucle pour chaque item


            for (var i = 0; i < items.Length; i++)
            {
                GameObject button = Instantiate(sellButtonPrefab, sellButtonsParent);
                SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
                buttonScript.itemName.text = items[i].itemName;
                buttonScript.itemImage.sprite = items[i].image;
                buttonScript.itemPrice.text = items[i].price.ToString();
                buttonScript.item = items[i];
                Debug.Log(items[i]);
            }
    }
}
