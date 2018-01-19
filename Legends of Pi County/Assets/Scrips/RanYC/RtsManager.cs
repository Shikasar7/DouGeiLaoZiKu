using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsManager : MonoBehaviour {

    public static RtsManager Current = null;

	// Use this for initialization
	void Start () {
        Current = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
