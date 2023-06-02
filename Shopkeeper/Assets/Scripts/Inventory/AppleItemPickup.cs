using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class AppleItemPickup : MonoBehaviour
{

    void Pickup()
    {
        InventoryManager.inventoryInstance.AddApple();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}