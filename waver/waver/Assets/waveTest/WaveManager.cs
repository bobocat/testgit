using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public Animator[] wavers;
    public float timeOffset = .1f;
    private float nextTriggerTime = 0;
    private int nextWaver = 0;
    public float timeError = 0f;

    public Text offsetText;
    public Text errorText;

    public struct waver
    {
        public Animator anim;
        public int loops;
    }

    // Use this for initialization
    void Start () {

        nextWaver = wavers.Length + 3;  // don't start right away
        SetTimeOffset(timeOffset);
        SetTimeError(timeError);
	}
	
	// Update is called once per frame
	void Update () {

        float randy;

        while ((Time.timeSinceLevelLoad >= nextTriggerTime) && (wavers.Length > nextWaver))
        {
            randy = Random.Range(timeError * -1f, timeError);
            wavers[nextWaver].Play("UpDown");
            nextWaver++;

            nextTriggerTime += timeOffset + randy;
            //nextTriggerTime += timeOffset;
        }
	
	}


    public void SetTimeError(float val)
    {
        timeError = val;
        errorText.text = (timeError.ToString("F2") + " sec");
    }

    public void SetTimeOffset(float offset)
    {
        timeOffset = offset;
        nextTriggerTime = Time.timeSinceLevelLoad + timeOffset;
        offsetText.text = (timeOffset.ToString("F2") +" sec");
    }

    public void StartSim()
    {
        nextWaver = 0;
        nextTriggerTime = Time.timeSinceLevelLoad + timeOffset;
    }

}
