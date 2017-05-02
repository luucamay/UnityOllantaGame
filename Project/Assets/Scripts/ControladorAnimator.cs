using UnityEngine;
using System.Collections;

public class ControladorAnimator : MonoBehaviour {
	private Animator animator;
	void Awake () {
		animator = GetComponent<Animator> ();
	}
	public void Caminar(){
		//animator.SetBool ();
	}
}
