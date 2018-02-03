using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CashBoxManager : MonoBehaviour {
    public Text Cashfeild;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        Cashfeild.text = "$" + (int)Player.Default.Credits;	
	}
}
