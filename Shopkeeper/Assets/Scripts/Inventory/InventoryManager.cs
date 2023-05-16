using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryInstance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        inventoryInstance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
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
