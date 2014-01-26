using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractObject : MonoBehaviour {
	public player.DrugEnums[] contains;
	private bool empty = false;

	public Transform tpPoint1, tpPoint2;

	public void teleportPlayer(Transform plyr) {
		float d1 = Vector3.Distance(plyr.position, tpPoint1.position);
		float d2 = Vector3.Distance(plyr.position, tpPoint2.position);

		plyr.position = (d1 < d2) ? tpPoint2.position : tpPoint1.position;
	}

	public List<player.DrugEnums> getItems() {
		List <player.DrugEnums> result = new List<player.DrugEnums>();

		if(empty) {
			return result;
		}

		foreach(player.DrugEnums item in contains) {
			result.Add(item);
		}

		empty = true;
		return result;
	}

}
