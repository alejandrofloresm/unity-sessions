using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public bool damage = false;

  public Transform SpawnBulletPosition;

  public Transform Bullet;

  public GameObject ShipMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
      Shoot();
    }
	}

  void Shoot() {
    Instantiate(Bullet, SpawnBulletPosition.position, Quaternion.identity);
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Metheorite") {
      Damaged();
    }
  }

  void Damaged() {
    if (damage) {
      return;
    }
    damage = true;
    ShipMesh.GetComponent<Renderer>().material.color = Color.red;
    Invoke("NotDamaged", 2);
  }

  void NotDamaged() {
    damage = false;
    ShipMesh.GetComponent<Renderer>().material.color = Color.white;
  }
}
