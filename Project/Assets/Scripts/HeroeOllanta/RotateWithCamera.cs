using UnityEngine;
using System.Collections;

public class RotateWithCamera : MonoBehaviour {
	private Transform target;
//	private float offset=1f;
	void Start () {
		target = GameObject.FindWithTag ("Head").transform;
	}
	
	void FixedUpdate () {
		RotarJuntoConLaCamara ();
//		transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,target.localPosition.z+offset);

	}

	void RotarJuntoConLaCamara(){
		transform.rotation=Quaternion.Euler(0,target.rotation.eulerAngles.y,0);
	}
}
