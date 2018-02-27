using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//确保blip公有且可访问
public class VisibilityManager : MonoBehaviour {
    public float TimeBetweenChecks = 1;
    //1S检测一次
    public float VisibleRange = 100;
    //100M范围内显示单位
    private float waited = 10000;


	void Update () {
        waited += Time.deltaTime;
        if (waited <= TimeBetweenChecks)
            return;

        waited = 0;

        //收集标志 以确定是否使用
        List<MapBlip> pBlips = new List<MapBlip>();
        List<MapBlip> oBlips = new List<MapBlip>();

        foreach (var p in RtsManager.Current .Players)
        {
            foreach (var u in p.ActiveUnits )
            {
                var blip = u.GetComponent<MapBlip>();
                if (p == Player.Default) pBlips.Add(blip);
                else oBlips.Add(blip);
            } 
        }
        foreach (var o in oBlips)
        {
            bool active = false;
            foreach (var p in pBlips )
            {
                var distance = Vector3.Distance(o.transform.position, p.transform.position);
                if (distance<=VisibleRange )
                {
                    active = true;
                    break;
                }
            }
            o.Blip.SetActive(active);
            foreach (var r in o.GetComponentsInChildren<Renderer>())   r.enabled = active; 
        }
    }
}
