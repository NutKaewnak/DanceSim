using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text time;
	bool isStart = false;
	float counter;
	float min;
	float sec;

	void start(){
	
	}

	void Update () {
		Debug.Log(isStart);
		if(isStart = true){
			counter += Time.deltaTime;
			floatToTime();
		}
		
	}

	void floatToTime(){
		min = Mathf.Floor(counter/60);
		sec = (counter)%60;
		time.text = (min + "." + Mathf.RoundToInt(sec));
	}

	public void setStart(){
		isStart = true;
	}
	public void setStop(){
		isStart = false;
	}

}
