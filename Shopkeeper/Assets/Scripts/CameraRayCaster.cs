using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCaster : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 15))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                hitObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
