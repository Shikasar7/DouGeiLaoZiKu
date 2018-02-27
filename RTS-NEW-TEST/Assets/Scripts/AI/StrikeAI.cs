using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StrikeAI : AiBehavior {

    public int StudentRequired = 5;

    public float TimeDelay = 20;

    public float SquadSize = 0.5f;

    public int IncreastPerWave = 10;
    public override void Execute()
    {
        var ai = AiSupport.GetSupport(this.gameObject);
        

        int wave = (int)(ai.Student.Count * SquadSize);
        StudentRequired += IncreastPerWave;

        foreach(var p in RtsManager .Current .Players)
        {
            if (p.IsAi)
                continue;
            for (int i = 0; i < wave; i++)
            {
                var students = ai.Student[i];
                var nav = students.GetComponent<RightClickNavigation>();
                nav.SendToTarget(p.Location.position);

            }
            return;
        }
    }
    public override float GetWeight()
    {
        if (TimePassed < TimeDelay)
            return 0;
        TimePassed = 0;

        var ai = AiSupport.GetSupport(this.gameObject);
        if (ai.Student.Count < StudentRequired)
            return 0;
        return 1;
    }
}
