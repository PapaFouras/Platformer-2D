using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{

      public static LoadAndSaveData instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }
        instance = this;
    
    }

    private void Start() {

        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount",0);
        Inventory.instance.UpdateTextUI();

        // chargement

    string[] itemsSaved = PlayerPrefs.GetString("InventoryItems","").Split(new string [] {","}, System.StringSplitOptions.RemoveEmptyEntries);

    for (var i = 0; i < itemsSaved.Length; i++)
    {
        //Ajoute l'item à l'inventaire
        int id = int.Parse(itemsSaved[i]);
        Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
        Inventory.instance.content.Add(currentItem);
        
        

    }
    Inventory.instance.UpdateTextUI();


        
    }
    
public void SaveData(){



PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

if(CurrentSceneManager.instance.levelToUnlock >  PlayerPrefs.GetInt("levelReached",1)){
    PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock );
}

// sauvegarde

string itemsInInventory = string.Join(",",Inventory.instance.content.Select(x => x.id));
PlayerPrefs.SetString("InventoryItems",itemsInInventory);


}

}
