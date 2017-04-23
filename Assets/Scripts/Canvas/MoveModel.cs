using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveModel : MonoBehaviour {

	public DragModel model;
	public InputField startTime;
	public InputField stopTime;
	public Scrollbar scroll;
	public float maxlenght = 900;

	private float startTimeToSec =0;
	private float startMin =0;
	private float startSec =0;
	
	private float stopTimeToSec =900;
	private float stopMin =0;
	private float stopSec =0;

	void Update(){
		dragIsEnd();
	}

	public void moveIsClicked(){
		model.setMoved();

		startMin = Mathf.Floor(float.Parse(startTime.text));
		startSec = ((float.Parse(startTime.text))-startMin)*100;
		startTimeToSec = startMin*60+startSec;
		scroll.value = startTimeToSec / maxlenght;

		stopMin = Mathf.Floor(float.Parse(stopTime.text));
		stopSec = ((float.Parse(stopTime.text))-stopMin)*100;
		stopTimeToSec = stopMin*60+stopSec;
	}

	void dragIsEnd(){
		if(model.getCheckEndDrag()){
			scroll.value = stopTimeToSec / maxlenght;
		}
	}
}
