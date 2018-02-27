using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public RectTransform ViewPort;
    public Transform Corner1, Corner2;
    //小地图视角范围和尺寸(两角)

    public GameObject BlipPrefab;
    //在地图上显示单位坐标
    public static Map Current;

    private Vector2 terrainSize;

    private RectTransform mapRect;

    public Map()
    {
        Current = this;
    }

	// Use this for initialization
	void Start () {
        terrainSize = new Vector2
        (
            Corner2.position.x - Corner1.position.x,
            Corner2.position.z - Corner1.position.z);

        mapRect = GetComponent<RectTransform>();

    }
	
    public Vector2 WorldPositionToMap(Vector3 point)
        //把世界位置转化为地图函数
    {
        var pos = point - Corner1.position;
        //得到当前位置相对于地形角落的位置
        var mapPos = new Vector2(
            point.x / terrainSize.x * mapRect.rect.width,
            point.z / terrainSize.y * mapRect.rect.height);
        //缩放适应地图
        return mapPos;
    }//返回地图位置
	// Update is called once per frame
	void Update () {
        ViewPort.position = WorldPositionToMap(Camera.main.transform.position);
		
	}
}
