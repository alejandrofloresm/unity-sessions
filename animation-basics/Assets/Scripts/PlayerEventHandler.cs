using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour {
    void OnAnimationDeadEnd() {
        Debug.LogError("OnAnimationDeadEnd()");
    }
}
