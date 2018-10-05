using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text LifeText;
    public int Life = 10;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Life--;
        }
	}

    void FixedUpdate() {
        UpdateUI();
    }

    void UpdateUI() {
        LifeText.text = "" + Life;
    }
}
