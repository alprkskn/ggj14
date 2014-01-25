using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : Singleton<SceneManager> {

	public List<InteractObject> interactables;
	public GameObject[] lsdObjects;
	public GameObject[] mushObjects;
	public GameObject[] weedObjects;
	public GameObject[] vodkaObjects;

	public Transform playerPrefab;

	private GameObject player = null;

	[HideInInspector]
	public Vector3 spawnPoint;

	private int numOfKeys = 0;
	private int currentKeys = 0;
	public int FoundKeys {
		get { return this.currentKeys; }
	}

	public bool CanFinish {
		get { return this.numOfKeys <= this.currentKeys; }
	}
	// Use this for initialization
	void Start () {
		foreach(GameObject go in lsdObjects) {
			go.SetActive(false);
		}
		foreach(GameObject go in mushObjects) {
			go.SetActive(false);
		}
		foreach(GameObject go in weedObjects) {
			go.SetActive(false);
		}
		foreach(GameObject go in vodkaObjects) {
			go.SetActive(false);
		}
		currentKeys = 0;
		numOfKeys = findKeysInScene();
		spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
		player = Instantiate(playerPrefab, spawnPoint, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private int findKeysInScene() {
		return GameObject.FindGameObjectsWithTag("Key").Length;
	}

	private IEnumerator revealObjects(Player.DrugEnums type) {
		yield return null;
	}

	private IEnumerator hideObjects(Player.DrugEnums type) {
		yield return null;
	}

	public void substanceUsed(Player.DrugEnums type) {

	}

	public void finishLevel() {
		Debug.Log ("Zaaa Bitti.");
	}
}
