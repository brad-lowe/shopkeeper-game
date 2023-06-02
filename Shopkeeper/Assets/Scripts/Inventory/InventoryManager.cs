using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Apple : Item
{
    public Apple()
    {
        this.icon = Resources.Load<Sprite>("Final_Item_Sprites");
    }
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryInstance;
    public List<Item> items = new List<Item>();
    public List<Item> apples = new List<Item>();
    public List<Item> wood = new List<Item>();
    public List<Item> steel = new List<Item>();
    public List<Item> cilantro = new List<Item>();
    public List<Item> weapons = new List<Item>();
    
    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        inventoryInstance = this;
    }

    public void Add(Item item) {
        if (item is Apple)
            AddApple();
    }

    public void AddApple()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Final_Item_Sprites");
        apples.Add(item);
    }

    public void RemoveApple()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Final_Item_Sprites");
        apples.Remove(item);
    }
    public void CraftGarnishedSword()
    {
        if (wood.Count != 0 && steel.Count != 0 && cilantro.Count != 0)
        {
            wood.Remove(wood[0]);
            steel.Remove(steel[0]);
            cilantro.Remove(cilantro[0]);
            Item cilsword = (Item)ScriptableObject.CreateInstance("Item");
            cilsword.id = weapons.Count;
            cilsword.itemName = "Garnished Sword";
            cilsword.icon = null; // Replace with icon for sword
            cilsword.value = 1;
        }
    }
    public void ListItems()
    {
        foreach(var item in items)
        {
            //inventoryItem = new GameObject();
            //GameObject obj = Instantiate(inventoryItem,itemContent);

            //string itemName = obj.transform.Find("itemName").GetComponent<string>();
            //Debug.Log(itemName);
        }
    }

}
