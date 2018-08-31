using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Debug
{
    public class TriggerColliderDebug : MonoBehaviour {

        public bool debugColor = true;
        public bool debugText = true;

        public Color meEnter = Color.green;
        public Color meStay = Color.yellow;
        private Color meExit;
        public Color otherEnter = Color.yellow;
        public Color otherStay = Color.red;
        private Color otherExit;

        void Start () {
            meExit = gameObject.GetComponent<Renderer>().material.color;
        }

        private void eventEnter(string method, GameObject other) {
            showText(method, other);
            otherExit = other.GetComponent<Renderer>().material.color;
            showColor(meEnter, gameObject);
            showColor(otherEnter, other);
        }

        private void eventStay(string method, GameObject other) {
            showText(method, other);
            showColor(meStay, gameObject);
            showColor(otherStay, other);
        }

        private void eventExit(string method, GameObject other) {
            showText(method, other);
            showColor(meExit, gameObject);
            showColor(otherExit, other);
        }

        private void showText(string method, GameObject other) {
            if (debugText) {
                Debug.Log("Event: " + method + " " + this.gameObject.name + " -> " + other.name);
            }
        }

        private void showColor(Color color, GameObject to) {
            if (debugColor) {
                to.GetComponent<Renderer>().material.color = color;
            }
        }

        void OnTriggerEnter(Collider collider) {
            eventEnter("OnTriggerEnter", collider.transform.gameObject);
        }

        void OnTriggerStay(Collider collider) {
            eventStay("OnTriggerStay", collider.transform.gameObject);
        }

        void OnTriggerExit(Collider collider) {
            eventExit("OnTriggerExit", collider.transform.gameObject);
        }

        void OnCollisionEnter(Collision collision) {
            eventEnter("OnCollisionEnter", collision.transform.gameObject);
        }

        void OnCollisionStay(Collision collision) {
            eventStay("OnCollisionStay", collision.transform.gameObject);
        }

        void OnCollisionExit(Collision collision) {
            eventExit("OnCollisionExit", collision.transform.gameObject);
        }
    }
}

