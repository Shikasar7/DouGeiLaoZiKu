using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//附加到游戏单位上 在小地图中显示

public class MapBlip : MonoBehaviour {

    private GameObject blip;

    public GameObject Blip { get { return blip; } }

    // Use this for initialization
    private void Start () {
        blip = GameObject.Instantiate(Map.Current.BlipPrefab);
        blip.transform.parent = Map.Current.transform;
        var color = GetComponent<Player>().Info.AccentColor ;
        blip.GetComponent<Image>().color = color;
	}
	
	// Update is called once per frame
	void Update () {
        blip.transform.position = Map.Current.WorldPositionToMap(transform.position);
	}
    void OnDestroy()
    {
        GameObject.Destroy(blip);
        
    }
}
