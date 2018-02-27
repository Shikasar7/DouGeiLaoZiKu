using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkColor : MonoBehaviour {
    public MeshRenderer[] Renderers;
    void Start()
    {
        var color = GetComponent<Player>().Info.AccentColor;
        //从Player中获取颜色

        foreach (var r in Renderers)
        {
            r.material.color = color;
        }
    }
	}

