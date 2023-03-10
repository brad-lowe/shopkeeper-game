using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCaster : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.one);
        bool state = Input.GetMouseButtonDown(0);
        if (hitInfo.collider != null)
        {
            Debug.Log('h');
            GameObject hitObject = hitInfo.collider.gameObject;
            Debug.Log(hitObject);
            if (state)
            {
                hitObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
