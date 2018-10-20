using UnityEngine;
using System.Collections;

public class DisperseTornado : MonoBehaviour {
	public GameObject staff;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "Thunderfury") {
			Destroy (this.gameObject);
		}
	}
}
