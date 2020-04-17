using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{

    void Start() {
        Invoke("KillMe", 3f);        
    }

    private void KillMe() {
        Destroy(gameObject);
    }

    void Update() {
        
    }
}
