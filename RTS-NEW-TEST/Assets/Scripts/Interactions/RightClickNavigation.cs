using UnityEngine;
using System.Collections;
using UnityEngine.AI;
//右键寻路
public class RightClickNavigation : Interaction {

	public float RelaxDistance = 5;//告诉单位到目的地后留在一个范围就好了，不用挤在一起

    private NavMeshAgent agent;
	private Vector3 target = Vector3.zero;
    //目的地
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
    //判断是否选中
    public  void SendToTarget(Vector3 pos)
    {
        target = pos;
        SendToTarget();
    }

	public void SendToTarget()
	{
		agent.SetDestination (target);
		agent.Resume ();
		isActive = true;
	}
	// 判断代理状态
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
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
            //正被导航代理时如果很近应停下来
		}
	}
}
