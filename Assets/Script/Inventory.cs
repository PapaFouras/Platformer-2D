
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Inventory : MonoBehaviour
{
    public PlayerEffect playerEffect;

    public int coinsCount;

    public Text coinsCountText;

public List<Item> content = new List<Item>();

public Image itemImageUI;
public Text itemNameUI;
public Sprite emptyItemImage;

private int currentContentIndex = 0;

    public static Inventory instance;
    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    private void Start() {
        UpdateInventoryUI();
    }

    public void AddCoins(int count){
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count){
        coinsCount -= count;
       UpdateTextUI();
    }

    public void UpdateTextUI(){
        coinsCountText.text = coinsCount.ToString();
    }

    public void ConsumeItem(){

        if(content.Count == 0){
            return;
        }
        Item currentItem = content[currentContentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        playerEffect.AddSpeed(currentItem.speedGiven,currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();

    }

    public void GetNextItem(){

        if(content.Count == 0){
            return;
        }
        currentContentIndex ++;
        if(currentContentIndex > content.Count -1){
            currentContentIndex = 0;
        }
        UpdateInventoryUI();
        
    }

    public void GetPreviousItem(){
         if(content.Count == 0){
            return;
        }
        currentContentIndex --;
        if(currentContentIndex < 0){
            currentContentIndex = content.Count -1;
        }
        UpdateInventoryUI();

    }

    public void UpdateInventoryUI(){
            if(content.Count > 0){
                itemImageUI.sprite = content[currentContentIndex].image;
                itemNameUI.text = content[currentContentIndex].name;
            }
            else{
                itemImageUI.sprite = emptyItemImage;
                itemNameUI.text = "";
            }
    }


}
