using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Invetory", menuName = "InventoryInstance/Inventory")]
public class InventoryObj : ScriptableObject
{
    public int baseInventorySize = 5;
    public int InventorySize = 5;

    public List<InventoryItem> inventoryList = new List<InventoryItem>();

    public void AddItem(ItemObj itemAdd, int amountAdd)
    {
        bool exists = false;
        foreach (InventoryItem items in inventoryList) { Debug.Log(items.item.name); }  
        for(int index = 0; index < inventoryList.Count; index++)
        {
            if (inventoryList[index].item == itemAdd)
            {
                inventoryList[index].AddAmount(amountAdd);
                exists = true;
            }
        }

        if (!exists)
        {
            inventoryList.Add(new InventoryItem(itemAdd, amountAdd));
        }
    }
}

[System.Serializable]
public class InventoryItem
{
    public ItemObj item;
    public int amount;
    
    public InventoryItem(ItemObj itemObject, int amountObject)
    {
        item = itemObject;
        amount = amountObject;
    }

    public void AddAmount(int amountAdd)
    {
        amount += amountAdd;
    }

}
