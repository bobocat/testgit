using UnityEngine;
using System.Collections;

public class Stuff : MonoBehaviour {

	void Start(){

	}

	public void StopOneSound(GameObject g){

		g.GetComponent<AudioSource>().Stop();

	}

	public void PlayAnim(){

		if (GetComponent<Animator>() != null)
		{
			Debug.Log("playing animation");
			GetComponent<Animator>().Play("gong");
		}
	}

}
