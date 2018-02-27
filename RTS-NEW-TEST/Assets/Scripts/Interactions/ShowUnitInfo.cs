using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowUnitInfo : Interaction {
    //可调用  
    public string Name;
    public float MaxHealth, CurrentHealth;
    public Sprite ProfilePic;
    //各种显示的信息
    bool show = false;
    //默认关闭显示

    public override void Select()
    {
        show = true;
    }
    void Update()
    {
        if (!show)
            return;  
        InfoManager.Current.Setpic(ProfilePic);
        InfoManager.Current .SetLines (
            Name,
            CurrentHealth +"/"+MaxHealth ,
            "Owner:"+GetComponent <Player>().Info.Name);
    }
    public override void Deselect()
    {
        InfoManager.Current.Clearpic();
        InfoManager.Current.ClearLines();
        show = false;
    }
   
}
