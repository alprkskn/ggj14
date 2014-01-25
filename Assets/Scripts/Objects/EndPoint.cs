using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {
	void OnTriggerEnter(Collider c) {
		if(c.tag == "Player")
		{
			if(SceneManager.Instance.CanFinish) {
				SceneManager.Instance.finishLevel();
			}
		}
		Debug.Log("geldi. " + c.tag);
	}
}
