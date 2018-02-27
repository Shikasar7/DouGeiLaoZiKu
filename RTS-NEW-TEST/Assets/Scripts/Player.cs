using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public PlayerSetupDefinition Info;
    public static PlayerSetupDefinition Default;
    //使PlayerSetuoDefinition可调用 并静态管理
    void Start()
    {
        Info.ActiveUnits.Add(this.gameObject);

    }
     void OnDestroy()
    {
        Info.ActiveUnits.Remove(this.gameObject);
        
    }
}
