using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampUI : MonoBehaviour {

    public Canvas carMenuCanvas;

    private Vector3 carMenuPos;

    public GameObject scrollBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        carMenuPos = GameObject.FindGameObjectWithTag("GameScene").transform.position;
        carMenuCanvas.transform.position = carMenuPos;

        if (Input.GetKey("1")) {
            scrollBar.GetComponent<Scrollbar>().value += 0.02f;
        }

        if (Input.GetKey("2")) {
            scrollBar.GetComponent<Scrollbar>().value -= 0.02f;
        }

        if (Input.GetKeyDown("3")) {
            scrollBar.GetComponent<Scrollbar>().value = 1f;
        }


    }
}
