using UnityEngine;
using System.Collections;

public class SpawnOgres : MonoBehaviour {
	public GameObject ogre1;
	public GameObject ogre2;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision otherObj) {
		if(otherObj.gameObject.tag == "Player"){
			Debug.Log("Here");
			Instantiate (ogre1,player.transform.position,Quaternion.identity);
			Instantiate (ogre2);
		}
	}
}
