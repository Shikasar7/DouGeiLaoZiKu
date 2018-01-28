using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitAction : ActionBehavior  {

    public GameObject prefab;
    public float Cost =0;
    private PlayerSetupDefinition player;


	// Use this for initialization
	void Start () {
        player = GetComponent<Player>().Info;
        
	}
    public override System.Action  GetClickAction ()
    {
        return delegate ()
        {
            if (player.Credits < Cost)
            {
                Debug.Log("Not Enough Money" + Cost);
                return;
            }
            var go = (GameObject)GameObject.Instantiate(
                prefab,
                transform.position,
                Quaternion.identity);
            go.AddComponent<Player>().Info = player;
            go.AddComponent<RightClickNavigation>();
            go.AddComponent<ActionSelect>();
            player.Credits -= Cost;
            //最好还需要先获取位置，防止被卡在里面；35
        };
    }
	// Update is called once per frame
	void Update () {
		
	}
}
