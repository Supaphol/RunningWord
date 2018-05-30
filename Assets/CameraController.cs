using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player; 

	private Vector3 offset;  
	// Use this for initialization
	void Start () {
		offset = (transform.position - player.transform.position);
		// offset = (transform.position - (new Vector3(player.transform.position.x,0,0)));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(player == null)
		return;
		// transform.position = player.transform.position + offset;
		transform.position = (new Vector3(player.transform.position.x,0,0)) + offset ;
	}
}
// sdlfjifjseiofjioejfojsofjlkm
