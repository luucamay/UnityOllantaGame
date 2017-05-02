using UnityEngine;
using System.Collections;

public class RotateWithCamer : MonoBehaviour {
	private Transform target;
	void Start () {
		target = GameObject.FindWithTag ("Head").transform;
	}
	
	void FixedUpdate () {
		transform.rotation=Quaternion.Euler(0,target.rotation.eulerAngles.y,0);
	}
}
