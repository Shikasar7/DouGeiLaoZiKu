using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour {

    public List<GameObject> Student = new List<GameObject>();
    public List<GameObject> Highobject = new List<GameObject>();
    //Ai管理的单位

    public PlayerSetupDefinition Player = null;

    public static AiSupport GetSupport (GameObject go)
    {
        return go.GetComponent<AiSupport>();
    }

    public void Refresh()
    {
        Student.Clear();
        Highobject.Clear();
        foreach (var u in Player.ActiveUnits)
        {
            if (u.name.Contains("Student")) Student.Add(u);
            if (u.name.Contains("Command")) Highobject.Add(u);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
