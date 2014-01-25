using UnityEngine;
using System.Collections.Generic;

public class PutCubes : MonoBehaviour {
	public int width;
	public int height;

	public Material tileMat;
	// Use this for initialization
	void Start () {
		for (int i=0; i < width; i++)
		{
			for (int j=0; j< height; j++) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = new Vector3(i, 0, j);
				cube.transform.parent = this.gameObject.transform;
				cube.renderer.material = tileMat;
			}
		}

		for(int i = 0; i < width; i++) {
			for(int j = 1; j < 6; j++) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = new Vector3(i, j, height);
				cube.transform.parent = this.gameObject.transform;
				cube.renderer.material = tileMat;

				Vector3[] meshNormals = cube.GetComponent<MeshFilter>().mesh.normals;
				Vector3[] invertedNormals = new Vector3[meshNormals.Length];
				int count = 0;
				foreach(Vector3 n in meshNormals)
				{
					invertedNormals[count++] = -n;
				}
				cube.GetComponent<MeshFilter>().mesh.normals = invertedNormals;
			}
		}

		for(int i = 0; i < width; i++) {
			for(int j = 1; j < 3; j++) {
				if(i <= 15 || i >= 20)
				{
					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
					cube.transform.position = new Vector3(i, j, 2);
					cube.transform.parent = this.gameObject.transform;
					cube.renderer.material = tileMat;
				}
			}
		}

		Camera cam = Camera.main;

		cam.fieldOfView = 40;
		cam.transform.position = new Vector3(width / 2f, 7f, -9f);
		cam.transform.Rotate(Vector3.right * 20);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
