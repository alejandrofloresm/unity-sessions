using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeChangesPlayerLife
{
	public class GameMaster : MonoBehaviour {

        public GameObject Sphere;
        public Color Color;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

        void OnMouseDown() {
            ChangeColor();
        }

        void ChangeColor() {
            Sphere.GetComponent<Renderer>().material.color = Color;
        }
	}
}
