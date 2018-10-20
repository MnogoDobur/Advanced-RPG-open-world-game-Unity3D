using UnityEngine;
using System.Collections;

public class KeyZone1 : MonoBehaviour {
    public GameObject key;
    public GameObject door;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        
    
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.key);
            Destroy(this.door);
        }
    }

}
