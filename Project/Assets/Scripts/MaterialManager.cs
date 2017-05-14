using UnityEngine;
using System.Collections;

public class MaterialManager : MonoBehaviour {
	MeshRenderer renderer;
	public Material  [] nuevoMaterial;
	void Awake () {
		renderer = GetComponent <MeshRenderer> ();
	}
	
	void Update () {
	
	}
	public void cambiarMaterial(){
		renderer.materials = nuevoMaterial;

	}
}
