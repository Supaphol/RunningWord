using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPlayScene : MonoBehaviour {

private int stage;
private int level;

private static int last;
private string text ;
private float currentTime;
	// Use this for initialization
	void Start () {
		if(last != 0){
			level = last % 5 + 1;
			stage = last / 5 + 1;
		}

		currentTime = Time.time+3.0f;
		text = "PlayScene";
		text = text+stage+"-"+level;
		last ++;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(currentTime);
		Debug.Log(Time.time);
		if(Time.time > currentTime){
			Debug.Log("in");
			SceneManager.LoadScene(text);
		}
	}
}
