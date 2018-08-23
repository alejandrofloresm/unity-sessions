using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeChangesPlayerLife
{
	public class GameMaster : MonoBehaviour {

        public Models.Player Player;

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

        void OnMouseDown() {
            Player.DealDamage(1);
        }

	}
}
