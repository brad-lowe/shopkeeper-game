using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShake : Minigame
{
    // Start is called before the first frame update
    Vector3 lastmouseposition;
    int score = 0;
    int numApples = 0;
    float timer = 5f;
    void Start()
    {
        lastmouseposition = Input.mousePosition;
    }
    
    /* 
    
    User has to keep their mouse moving at a rate of more than 30/second. 
    Score counter increases by 1 if the user keeps it at the correct speed
    Decreases by 5 if they are too slow
    Once score reaches 100, the user gets an apple and it score resets to 0  
    
     */
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (score < 100)
        {
            if ((Input.mousePosition-lastmouseposition).magnitude >30)
            {
                lastmouseposition = Input.mousePosition;
                score++;
                Debug.Log($"# of apples: {InventoryManager.inventoryInstance.apples.Count} Score: {score}");
            }
            else
            {
                lastmouseposition = Input.mousePosition;
                if (score > 0 && score>=5)
                {
                    score-=5;
                } else if(score > 0)
                {
                    score = 0;
                }
                Debug.Log($"# of apples: {InventoryManager.inventoryInstance.apples.Count} Score: {score}");
            }
        }
        else
        {
            InventoryManager.inventoryInstance.AddApple();
            Debug.Log($"You got an apple! Total apples: {InventoryManager.inventoryInstance.apples.Count}");
            score = 0;
        }
        if(timer <= 0f) {
            EndMinigame();
        }
    }

}
