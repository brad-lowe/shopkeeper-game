using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class InteractableSceneSwitch : MonoBehaviour, Interactable 
{ 
	GameObject player; 
	[SerializedField] string sceneName; 
    /*
        SerializedField will allow to make the sceneName variable editable in Unity 
    */

	void Start() {
		player = GameObject.Find("Player"); 

	}
	public void Interact () {
		SceneManager.LoadScene(sceneName); 
	}
	void Update() {
		float dist = (transform.position - player.transform.position).magnitude;
		if(dist < 1) {
			Interact(); 
		}
	}
}