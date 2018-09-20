using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject BulletEmissor;
	public GameObject Bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Shoot", 0, 2);
	}

	void Shoot() {
		Instantiate(Bullet, 
			BulletEmissor.transform.position,
			Quaternion.identity);
	}

}
