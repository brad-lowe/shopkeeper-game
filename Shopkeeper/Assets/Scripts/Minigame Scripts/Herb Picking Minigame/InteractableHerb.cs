using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHerb : MonoBehaviour, Interactable
{
    public Item item;

    // Update is called once per frame
    public void Interact()
    {
        //Debug.Log("clicked on " + this.gameObject.name);
    }
}
