using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GameObject bullet = createBullet();
            Vector3 mousePosition = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                10);
            Vector3 fakeTarget = Camera.main.ScreenToWorldPoint(mousePosition);
            bullet.transform.LookAt(fakeTarget);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * 1000);
        }
    }

    private GameObject createBullet() {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = gameObject.transform.position;
        go.transform.localScale = new Vector3(.5f, .5f, .5f);
        go.AddComponent<Rigidbody>();
        go.name = "bullet";
        return go;
    }
}
