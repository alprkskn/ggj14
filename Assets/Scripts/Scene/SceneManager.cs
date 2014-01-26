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

	public int nextLevel;

	private GameObject playerObject = null;

	[HideInInspector]
	public Vector3 spawnPoint;

	private int numOfKeys = 0;
	public int currentKeys = 0;
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
		playerObject = Instantiate(playerPrefab, spawnPoint, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private int findKeysInScene() {
		return GameObject.FindGameObjectsWithTag("Key").Length;
	}

	public void revealObjects(player.DrugEnums type) {
 		if(type == player.DrugEnums.LSD)
		{
			foreach(GameObject go in lsdObjects) {
				go.SetActive(true);
			}
		}
		if(type == player.DrugEnums.Smoke)
		{
			foreach(GameObject go in weedObjects) {
				go.SetActive(true);
			}
		}
		if(type == player.DrugEnums.Mushroom)
		{
			foreach(GameObject go in weedObjects) {
				go.SetActive(true);
			}
		}
		if(type == player.DrugEnums.Vodka)
		{
			foreach(GameObject go in vodkaObjects) {
				go.SetActive(true);
			}
		}
	}



	public void hideObjects(player.DrugEnums type) {
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
	}

	public void finishLevel() {
		Debug.Log ("Zaaa Bitti.");
		Application.LoadLevel(nextLevel);
	}
}
