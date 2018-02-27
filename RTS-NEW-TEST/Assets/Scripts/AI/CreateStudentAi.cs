using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStudentAi : AiBehavior  {

    public int StudentsPerBase = 5;
    public float Cost = 50;
    private AiSupport support;

    public override float GetWeight()
    {
        if (support == null)
            support = AiSupport.GetSupport(gameObject);

        if (support.Player.Credits < Cost)
            return 0;

        var students = support.Student.Count;
        var bases = support.Highobject.Count;

        if (bases == 0)
            return 0;

        if (students >= bases * StudentsPerBase) return 0;
        return 1;

    }
    public override void Execute()
    {
        Debug.Log(support.Player.Name + "is creating a student.");

        var bases = support.Highobject ;
        var index = Random.Range(0, bases.Count);
        var commandBase = bases[index];
        commandBase.GetComponent<CreateUnitAction>().GetClickAction()();
    }
}
