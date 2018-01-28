using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelect  : Interaction  {

    public override void Deselect()
    {
        ActionManager.Current.ClearButtons();
    }
    public override void Select()
    {
        ActionManager.Current.ClearButtons();
        foreach (var ab in GetComponents<ActionBehavior>())
        {
            ActionManager.Current.AddButton(
               ab.Buttonpic,
               ab.GetClickAction());
        }
    }
}
