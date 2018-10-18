using UnityEngine;
using System.Collections;

public class Metheorite : MonoBehaviour {

  private int Life = 5;

  public Transform ExplosionParticleSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Bullet") {
      TakeDamage(other.gameObject);
    }
  }

  void TakeDamage(GameObject bullet) {
    Destroy(bullet);
    Life--;
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {
      Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
  }

  void ResetColor() {
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }


}
