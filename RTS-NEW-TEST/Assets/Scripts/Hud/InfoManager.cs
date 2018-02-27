using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {
    public static InfoManager Current;
    public Image profilepic;
    public Text Line1, Line2, Line3;
   //三行文本面板

    public InfoManager ()
    {
        Current = this;
    }
    public void SetLines (string line1,string line2,string line3)
    {
        Line1.text = line1;
        Line2.text = line2;
        Line3.text = line3;
        //创建文本
    }
    public void ClearLines()
    {
        SetLines("", "", "");
        //清除文本为空格
    }
    public void Setpic(Sprite pic)
    {
        //头像
        profilepic.sprite = pic;
        profilepic.color = Color.white;
        //为确保能看见 把图片变成白色
    }
    public void Clearpic()
    {
        profilepic.color = Color.clear;

    }
	// Use this for initialization
	void Start () {
        ClearLines();
        Clearpic();
	   //清除图片和文本	
	}
	
	
}
