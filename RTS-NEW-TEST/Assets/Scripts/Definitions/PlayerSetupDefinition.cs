using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//在监视板中可见
public class PlayerSetupDefinition {

    public string Name;

    public Transform Location;
    //起始位置

    public Color AccentColor;
    //代表颜色

    public List<GameObject> StartingUnits = new List<GameObject>() ;
    //初始单位列表

    public List<GameObject> activeUnits = new List<GameObject>();

    public List<GameObject> ActiveUnits { get { return activeUnits; } }

    public bool IsAi;

    public float Credits;
    //管理积分
}
