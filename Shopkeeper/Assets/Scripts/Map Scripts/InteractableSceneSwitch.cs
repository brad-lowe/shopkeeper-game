using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class InteractableSceneSwitch : MonoBehaviour, Interactable 
{ 
	GameObject player; 
	[SerializeField] string sceneName; 
    /*
        SerializedField will allow to make the sceneName variable editable in Unity 
    */

	void Start() {
		if(player == null) {
		player = GameObject.Find("Player"); 
		}
	}
	public void Interact () {
		SceneManager.LoadScene(sceneName); 
	}
	void Update() {
		if(player != null) {
		float dist = (transform.position - player.transform.position).magnitude;
		if(dist < 1) {
			Interact(); 
			}
		}
	}
}