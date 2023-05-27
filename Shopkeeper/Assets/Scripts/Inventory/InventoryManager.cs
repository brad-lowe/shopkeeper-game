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

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        inventoryInstance = this;
    }

    public void AddApple()
    {
        Apple item = new Apple();
        apples.Add(item);
    }

    public void RemoveApple()
    {
        Apple item = new Apple();
        apples.Remove(item);
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
