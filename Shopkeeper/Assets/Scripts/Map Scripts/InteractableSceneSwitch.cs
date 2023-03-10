using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSceneSwitch : MonoBehaviour, Interactable
{
    GameObject player;

    void Start() {
        player = GameObject.Find("Player");
    }
    public void Interact() {
        Debug.Log("switch scene");
    }

    void Update() {
        float dist = (transform.position - player.transform.position).magnitude;
        Debug.Log(dist);
        if(dist < 1) {
            Interact();
        }
    }
}
