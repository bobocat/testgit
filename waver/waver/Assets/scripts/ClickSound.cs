﻿using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoSound(){

		GetComponent<AudioSource>().PlayOneShot(sound);

	}
}
