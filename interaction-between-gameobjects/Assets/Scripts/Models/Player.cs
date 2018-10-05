using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models {
    public class Player : MonoBehaviour {

        public int Life = 10;

        void OnGUI() {
            GUILayout.Label("Players life: " + Life);
            GUILayout.Label("Check: https://docs.unity3d.com/ScriptReference/GUILayout.Label.html");
        }

        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

        }

        public void DealDamage(int amount) {
            Life -= amount;
        }
    }
}

