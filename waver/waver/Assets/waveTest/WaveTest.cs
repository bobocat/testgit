using UnityEngine;
using System.Collections;

public class WaveTest : MonoBehaviour {

    public float startTime = 0f;
    private bool triggered = false;


	// Use this for initialization
	void Start () {

        startTime += Time.timeSinceLevelLoad;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.timeSinceLevelLoad >= startTime)
        {
            GetComponent<Animator>().Play("UpDown");
        }
	
	}
}
