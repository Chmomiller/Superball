using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour {
    public GameObject credits;
    public float scrollSpeed = -0.1f;
    // Use this for initialization
    void Start() {
        credits = GameObject.Find("Credits");
    }

    // Update is called once per frame
    void Update() {
        credits.transform.position -= new Vector3(0.0f, scrollSpeed, 0.0f);
    }

    void skipTo(string Team) {
    float x,y,z;
        switch (Team) {
            default:
                return;
        }
    credits.transform.position = new Vector3(x,y,z);
    }
}
