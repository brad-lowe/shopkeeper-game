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

class Cilantro : Item
{
    public Cilantro()
    {
        this.icon = Resources.Load<Sprite>("Cilantro");
    }
}

class Beatroot : Item
{
    public Beatroot()
    {
        this.icon = Resources.Load<Sprite>("Beatroot");
    }
}

class Zingseng : Item
{
    public Zingseng()
    {
        this.icon = Resources.Load<Sprite>("Zingseng");
    }
}

class Mushgloom : Item
{
    public Mushgloom()
    {
        this.icon = Resources.Load<Sprite>("Mushgloom");
    }
}
class MysteriousHerb : Item
{
    public MysteriousHerb()
    {
        this.icon = Resources.Load<Sprite>("MysteriousHerb");
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
    public List<Item> beatroots = new List<Item>();
    public List<Item> zingsengs = new List<Item>();
    public List<Item> mushglooms = new List<Item>();
    public List<Item> mysteriousHerbs = new List<Item>();
    public List<Item> weapons = new List<Item>();
    
    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        inventoryInstance = this;
        Object.DontDestroyOnLoad(this.gameObject);
    }

    public void Add(Item item) {
        if (item is Apple)
            AddApple();
        if (item is Cilantro)
            AddCilantro();
        if (item is Beatroot)
            AddBeatroot();
        if (item is Zingseng)
            AddZingseng();
        if (item is Mushgloom)
            AddMushgloom();
        if (item is MysteriousHerb)
            AddMysteriousHerb();
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

    public void AddCilantro()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Cilantro");
        cilantro.Add(item);
    }

    public void RemoveCilantro()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Cilantro");
        cilantro.Remove(item);
    }
    public void AddBeatroot()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Beatroot");
        beatroots.Add(item);
    }

    public void RemoveBeatroot()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Beatroot");
        beatroots.Remove(item);
    }
    public void AddZingseng()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Zingseng");
        zingsengs.Add(item);
    }

    public void RemoveZingseng()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Zingseng");
        zingsengs.Remove(item);
    }
    public void AddMushgloom()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Mushgloom");
        mushglooms.Add(item);
    }

    public void RemoveMushgloom()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("Mushgloom");
        mushglooms.Remove(item);
    }
    public void AddMysteriousHerb()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("MysteriousHerb");
        mysteriousHerbs.Add(item);
    }

    public void RemoveMysteriousHerb()
    {
        Item item = (Item)ScriptableObject.CreateInstance("Item");
        item.icon = Resources.Load<Sprite>("MysteriousHerb");
        mysteriousHerbs.Remove(item);
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
