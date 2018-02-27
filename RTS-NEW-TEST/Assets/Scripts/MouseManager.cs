using UnityEngine;
using System.Collections.Generic;

public class MouseManager : MonoBehaviour {


	public static MouseManager Current;

	public MouseManager()
	{
		Current = this;
	}

	private List<Interactive> Selections = new List<Interactive>();

	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButtonDown (0))
			return;

		var es = UnityEngine.EventSystems.EventSystem.current;
		if (es != null && es.IsPointerOverGameObject ())
			return;
       

		if (Selections.Count > 0) {
			if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
			{
				foreach(var sel in Selections)
				{
					if (sel != null) sel.Deselect();
				}
				Selections.Clear();
			}
		}//ctrl键全选单位

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (!Physics.Raycast (ray, out hit))
			return;
        //射线检测   如果没点到东西则跳过

		var interact = hit.transform.GetComponent<Interactive> ();
		if (interact == null)
			return;

		Selections.Add (interact);
		interact.Select ();
	}//如果检测到单位 则选中
}
