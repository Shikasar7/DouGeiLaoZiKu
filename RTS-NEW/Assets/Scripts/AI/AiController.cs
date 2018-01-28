using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {

    private List<AiBehavior> Ais = new List<AiBehavior>();
	// Use this for initialization
	void Start () {
        foreach (var ai in GetComponents<AiBehavior>())
            Ais.Add(ai);
	}
	
	// Update is called once per frame
	void Update () {
        float bestAiValue = float.MinValue;
        AiBehavior bestAi = null;

        foreach (var ai in Ais)
        {
            var aiValue = ai.GetWeight();
            //取最高值决定进行哪项Ai
            if (aiValue>bestAiValue ){
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }
        bestAi.Execute();
	}
}
