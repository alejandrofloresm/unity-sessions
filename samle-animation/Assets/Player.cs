using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int Life = 10;
	public float Speed = 0.1f;

	public Animator AnimatorController;

	public bool IsDead;

	void OnGUI() {
		GUILayout.Label("Life: " + Life);
	}


	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		gameObject.transform.Translate(new Vector3(horizontal * Speed, 0, 0));
		AnimatorController.SetFloat("Speed", Mathf.Abs(horizontal));
	}

	void OnTriggerEnter2D(Collider2D other) {
		Life = Life - 1;
		if (Life <= 0) {
			Dead();
		}
  }

	void Dead() {
		IsDead = true;
		AnimatorController.SetBool("Dead", IsDead);
	}
}
