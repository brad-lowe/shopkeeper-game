using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerController : MonoBehaviour
{
    //private MapPlayerController controller;
    public float speed = 10.0f;
    
    int Roll() {
        return 0;
    }

    // Start is called before the first frame update
    void Start() {
        //controller = GameObject.GetComponent<MapPlayerController>();
    }

    // Update is called once per frame
    void Update() {

        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.Translate(horizontal, vertical, 0);
    }
}