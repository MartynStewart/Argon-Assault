using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTest : MonoBehaviour{
    private Material myMat;                  //Ref point for setting player colour

    public Color    flashColour1;
    private Color   flashColour2 = new Color(255, 255, 0, 255);
    public bool usePublic = true;

    void Start() {
        myMat = GetComponent<MeshRenderer>().materials[0];
    }


    void Update() {
        if (usePublic) {
            myMat.color = flashColour1;
        } else {
            myMat.color = flashColour2;
        }
    }
}
