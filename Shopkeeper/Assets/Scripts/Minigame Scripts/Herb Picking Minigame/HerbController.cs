using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class HerbController : MonoBehaviour
{
    private List<Item> itemClasses;
    private List<InteractableHerb> items;
    private List<InteractableHerb> itemCopies;
    private int round = 1;
    private InteractableHerb itemLastClicked;
    private InteractableHerb itemToClick;
    private string nameToClick;
    private float timer = 3f;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(timerText.gameObject.name);
        items = new List<InteractableHerb>();
        itemCopies = new List<InteractableHerb>();
        GameObject[] itemObjects = GameObject.FindGameObjectsWithTag("Herb");
        foreach(GameObject i in itemObjects) {
            items.Add(i.GetComponent<InteractableHerb>());
        }
        BeginRound();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = (string) ((int)timer).ToString();

        if (Input.GetMouseButtonDown (0)) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);
            if (hit.collider != null && hit.collider.gameObject.tag == "Herb") {
                (hit.collider.gameObject.GetComponent<InteractableHerb>()).Interact();
                itemLastClicked = hit.collider.gameObject.GetComponent<InteractableHerb>();
                if(itemLastClicked.name.Contains(nameToClick)) {
                    Debug.Log("Correct!");
                    timer += 2f;
                    timerText.text = (string) ((int)timer).ToString();
                    NewRound();
                }
                else {
                    Debug.Log("Wrong!");
                    timer -= 3f;
                    timerText.text = (string) ((int)timer).ToString();
        }
            }
        }
        if (timer <= 0f) {
            EndGame();
        }
    }

    void BeginRound()
    {
        int numHerbs = round*8 + 10;

        itemLastClicked = null;
        Random rand = new Random();
        List<string> itemNames = new List<string>();

        foreach(InteractableHerb i in items) {
            itemNames.Add(i.gameObject.name);
        }

        int index = rand.Next(itemNames.Count);
        itemToClick = items[index];
        nameToClick = itemToClick.gameObject.name;
        Debug.Log("Choose " + nameToClick);

        List<InteractableHerb> itemsNotChosen = new List<InteractableHerb>(items);
        itemsNotChosen.Remove(items[index]);

        List<string> itemNamesNotChosen = new List<string>(itemNames);


        foreach(InteractableHerb i in itemsNotChosen) {
            itemNamesNotChosen.Add(i.gameObject.name);
        }

        for(int i = 0; i < numHerbs; i++) {
            index = rand.Next(itemsNotChosen.Count);
            Vector3 pos = new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), UnityEngine.Random.Range(-4.0f, 4.0f), 0);
            InteractableHerb itemToAdd = Instantiate(itemsNotChosen[index], pos, Quaternion.identity);
            itemCopies.Add(itemToAdd);
        }
        Vector3 posToClick = new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), UnityEngine.Random.Range(-4.0f, 4.0f), 1f);
        InteractableHerb itemToAddClick = Instantiate(itemToClick, posToClick, Quaternion.identity);
        itemCopies.Add(itemToAddClick);

        foreach(InteractableHerb i in items) {
            i.gameObject.SetActive(false);
        }

    }

    void NewRound() {
        round++;

        foreach(InteractableHerb i in itemCopies) {
            Destroy(i.gameObject);
        }
        itemCopies = new List<InteractableHerb>();
        foreach(InteractableHerb i in items) {
            i.gameObject.SetActive(true);
        }

        BeginRound();
    }

    void EndGame() {
        enabled = false;
        Debug.Log("GAME OVER");
    }

}
