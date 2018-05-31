using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPrePlayScene : MonoBehaviour {

private int stage =1;
private int level =1;

public static int lastScene =1;
private string text ;
private float currentTime;
	// Use this for initialization
	void Start () {
			level = lastScene % 5 + 1;
			stage = lastScene / 5 + 1;

		currentTime = Time.time+0.1f;
		text = "PrePlayScene"+stage+"-"+level;
		Debug.Log(level);
		lastScene ++;
	}

	// Update is called once per frame
	void Update () {
		
		if(Time.time > currentTime){
			Debug.Log("in");
			SceneManager.LoadScene(text);
		}
	}

	public static void decreaseLastScene(){
		lastScene = 1;
	}
}
