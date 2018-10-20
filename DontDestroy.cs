using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform);
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
