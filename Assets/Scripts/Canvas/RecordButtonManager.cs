using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecordButtonManager : MonoBehaviour {

	public float countTime;
	public bool isRecord;
	[SerializeField]
	private UnityAnimationRecorder recorder;
	public Text timeCounting;
	public GameObject CountDownPanel;

	public Scrollbar scroll;
	// Use this for initialization
	void Start () {
		isRecord = false;
	}
	
	// Update is called once per frame
	void Update () {
		countDownRecord ();
		setText();
	}

	void countDownRecord () {
		Debug.Log (isRecord);
		if (isRecord) {
			if (countTime <= 0) {
				recorder.StartRecording ();
				CountDownPanel.gameObject.SetActive(false);

			} else {
				countTime -= Time.deltaTime;
				countTime = Mathf.Max (0, countTime);
			}
		}
	}

	public void StartRecording () {
		countTime = 5;
		isRecord = true;
		CountDownPanel.gameObject.SetActive(true);
		scroll.value = Mathf.Max(0,scroll.value - 0.00666666667f);

	}

	void setText(){
		timeCounting.text = Mathf.Ceil(countTime).ToString();
	}

	public void StopRecording () {
		recorder.StopRecording ();
	}
}
