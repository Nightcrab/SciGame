using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelmanager : MonoBehaviour {
	public void loadlevel (string name){
		Debug.Log ("level load requested for:" +name);
		SceneManager.LoadScene(name);
	}
	public void QuitRequest (){
		Debug.Log ("i wanna quit!");
		Application.Quit();
	}
}