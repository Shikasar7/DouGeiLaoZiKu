using UnityEngine;
using System.Collections;

public class RightClickNavigation : Interaction {

	public float RelaxDistance = 5;//告诉单位到目的地后留在一个范围就好了，不用挤在一起

    private UnityEngine.AI.NavMeshAgent agent;
	private Vector3 target = Vector3.zero;
	private bool selected = false;
	private bool isActive = false;

	public override void Deselect ()
	{
		selected = false;
	}
	public override void Select ()
	{
		selected = true;
	}
	public void SendToTarget(Vector3 pos)
	{
		target = pos;
		SendToTarget ();
	}
	public void SendToTarget()
	{
		agent.SetDestination (target);
		agent.Resume ();
		isActive = true;
	}
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}	
	// Update is called once per frame
	void Update () {
		if (selected && Input.GetMouseButtonDown (1)) {
			var tempTarget = RtsManager.Current.ScreenPointToMapPosition(Input.mousePosition);
			if (tempTarget.HasValue) {
				target = tempTarget.Value;
				SendToTarget();
			}
		}
		if (isActive && Vector3.Distance (target, transform.position) < RelaxDistance) {
			agent.Stop ();
			isActive = false;
		}
	}
}
