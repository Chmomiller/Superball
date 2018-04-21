using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class changeSprite : MonoBehaviour {

    public Sprite salt;
    public Sprite schola;
    public Sprite might;
    public Sprite yam;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change(string filePath) {
        print(filePath);
        if (filePath == "salt") {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = salt;
        } else if (filePath == "schola") {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = schola;
        } else if (filePath == "might") {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = might;
        } else if (filePath == "yam") {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = yam;
        } else {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = null;
        }
        //GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(filePath);
        //GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(filePath);
        if (Resources.Load<Sprite>(filePath) == null) print("change fail:" +filePath);
    }
}
