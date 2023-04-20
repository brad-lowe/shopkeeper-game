using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void onCollisionEnter()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.Translate(horizontal, vertical, 0);
    }
}
