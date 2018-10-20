using UnityEngine;
using System.Collections;

public class spellCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") {
			Destroy (this.gameObject,0.4f);
		}
	}
}
