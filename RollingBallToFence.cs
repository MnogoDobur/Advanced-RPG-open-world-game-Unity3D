using UnityEngine;
using System.Collections;

public class RollingBallToFence : MonoBehaviour {
public GameObject obj;
	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision otherObj) {
    if (otherObj.gameObject.tag != "Player" && otherObj.gameObject.tag != "Terrain" && otherObj.gameObject.tag == "Fence") 
    {
        //Destroy (collision.gameObject);
        Destroy (obj);
    }
}
	// Update is called once per frame
	void Update () {
	
	}
}
