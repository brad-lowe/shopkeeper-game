﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableColorChange : MonoBehaviour, Interactable
{
    public void Interact()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}