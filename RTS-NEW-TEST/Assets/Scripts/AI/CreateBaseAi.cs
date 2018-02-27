using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CreateBaseAi : AiBehavior {

    private AiSupport support = null;

    public float Cost = 400;

    public int UnitsPerBase = 8;

    public float RangeFromStudent = 20;

    public int TriesPerStudent = 2;

    public GameObject BasePrefab;

    public override float GetWeight()
    {
        if (support == null)
            support = AiSupport.GetSupport(gameObject);

        if (support.Player.Credits < Cost || support.Student.Count == 0)
            return 0;

        if (support.Highobject.Count *UnitsPerBase <=support .Student .Count )
            return 1;
        return 0;

        return (support.Highobject.Count / UnitsPerBase) * support.Student.Count;
    }


    public override void Execute()
    {
        var go = GameObject.Instantiate(BasePrefab);
        go.AddComponent<Player>().Info = support.Player;

        foreach (var students in support.Student)
        {
            for (int i = 0; i < TriesPerStudent; i++)
            {
                var pos = students.transform.position;
                pos += Random.insideUnitSphere * RangeFromStudent;
                //保证高度在地形以上
                go.transform.position = pos;

                    if(RtsManager .Current .IsGameObjectSafeToPlace(go))
                {
                    support.Player.Credits -= Cost;
                    return; 
                }
            }
        }
        Destroy(go);
    }
}
