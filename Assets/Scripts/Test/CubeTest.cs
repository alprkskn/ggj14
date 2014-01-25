using UnityEngine;
using System.Collections.Generic;

public class CubeTest : MonoBehaviour {

	private Mesh cubeMesh;
	private GameObject go;

	public Material mat;

	// Use this for initialization
	void Start () {
		go = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cubeMesh = go.GetComponent<MeshFilter>().mesh;
		eliminateForwardFaces(cubeMesh);
		go.renderer.material = mat;
	}
	
	// Update is called once per frame
	void Update () {

		for(int i=0; i<cubeMesh.vertices.Length; i++) {
		}
	}

	void eliminateForwardFaces(Mesh mesh) {
		int count = 0;
		foreach(Vector3 v in mesh.normals) {
			float dot = Vector3.Dot (v, Vector3.forward); 
			if(dot == -1) {
				Debug.Log("lol " + mesh.vertices[count]);
				Debug.DrawLine(mesh.vertices[count], mesh.vertices[count] + v * 0.2f, Color.red, 100f);
			}
			count++;
		}

		int[] indices = mesh.GetTriangles(0);
		List<int> newIndices = new List<int>();

		foreach(int i in indices) {
			float dot = Vector3.Dot(mesh.normals[i], Vector3.forward);

			if(dot == 0) {
				newIndices.Add(i);
			}
			else {
				Debug.Log("excluded");
			}
		}

		mesh.SetTriangles(newIndices.ToArray(), 0);
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}
}
