using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace __Debug
{
    public class ObjectGuiVerbose : MonoBehaviour {

        [TextArea]
        public string text;

        public Color TextColor = Color.red;

        public int FontSize = 20;

        private bool valid = true;

        void OnGUI() {
            if (valid) {
                var style = new GUIStyle() {
                    normal = new GUIStyleState() {
                        textColor = TextColor
                    },
                    fontSize = FontSize
                };

                var position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                var textSize = GUI.skin.label.CalcSize(new GUIContent(text));

                GUI.Label(
                    new Rect(
                        position.x,
                        Screen.height - position.y,
                        textSize.x,
                        textSize.y),
                    text,
                    style
                );
            }
        }

        void Start() {
            if (string.IsNullOrEmpty(text)) {
                this.SetText(gameObject.name);
            }
            if (Camera.main == null) {
                valid = false;
                Debug.LogWarning("[ObjectGuiVerbose] Camera.main was not found");
            }
        }

        public void SetText(string text) {
            this.text = text;
        }

        public void Append(string text) {
            this.text += text;
        }

        public void NewLine(string text) {
            this.text += "\n" + text;
        }
    }
}
