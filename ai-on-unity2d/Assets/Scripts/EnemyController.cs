using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

  public enum EnemyStatus {
    patrol = 0,
    chase = 1
  }

  public EnemyStatus Status = EnemyStatus.patrol;

  public EnemyMovement EnemyMovement;

  public LayerMask RayMask;
	public float RayDistance = 5;

  // Use this for initialization
  void Start () {
    
  }
  
  void FixedUpdate() {
    Vector3 movement = new Vector3(EnemyMovement.Move, 0, 0);
    Vector3 rayDirection = movement * RayDistance;
		Debug.DrawRay(transform.position, rayDirection, Color.cyan);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, RayDistance, RayMask);
		if (hit.collider != null) {
			hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
      SetChase();
		}
  }

  // Update is called once per frame
  void Update () {
    
  }

  void SetChase() {
    Status = EnemyStatus.chase;
    gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
  }

  public void SetPatrol() {
    Status = EnemyStatus.patrol;
    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
  }
  
}
