using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float RunningSpeed = 2;
    public Animator AnimatorController;
    public bool Dead = false;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Kill();
        }
    }

    void LateUpdate() {
        Move();
    }

    void Move() {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 translate = new Vector3(horizontal * RunningSpeed, 0, 0);
        gameObject.transform.Translate(translate);
        AnimatorController.SetFloat("Speed", Mathf.Abs(horizontal * RunningSpeed));
    }

    void Kill() {
        Dead = true;
        AnimatorController.SetBool("Dead", Dead);
    }


}
