using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordButtonManager : MonoBehaviour {

	public float countTime;
	public bool isRecord;
#if UNITY_EDITOR
    [SerializeField]
	private UnityAnimationRecorder recorder;
#endif

    // Use this for initialization
    void Start () {
		isRecord = false;
	}
	
	// Update is called once per frame
	void Update () {
		countDownRecord ();
	}

	void countDownRecord () {
		Debug.Log (isRecord);
		if (isRecord) {
			if (countTime <= 0) {
				recorder.StartRecording ();
			} else {
				countTime -= Time.deltaTime;
				countTime = Mathf.Max (0, countTime);
			}
		}
	}

	public void StartRecording () {
		isRecord = true;
	}

	public void StopRecording () {
		recorder.StopRecording ();
	}
}
