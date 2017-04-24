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
	public GameObject previewBar;

	private float startTimeToSec =0;
	private float startMin =0;
	private float startSec =0;
	
	private float stopTimeToSec =900;
	private float stopMin =0;
	private float stopSec =0;

	private string name = "";
	private Vector3 newPosition;
	private Vector3 modelVelocity;

	private bool isPreview = false;

    private void Start()
    {
        scroll = Scrollbar.FindObjectOfType<Scrollbar>();
    }

    void Update(){
		checkTimeStop();
		moveModelinPreview();
	}

	public void moveIsClicked(){
		startMin = Mathf.Floor(float.Parse(startTime.text));
		startSec = ((float.Parse(startTime.text))-startMin)*100;
		startTimeToSec = startMin*60+startSec;

        scroll.value = startTimeToSec / maxlenght;

		stopMin = Mathf.Floor(float.Parse(stopTime.text));
		stopSec = ((float.Parse(stopTime.text))-stopMin)*100;
		stopTimeToSec = stopMin*60+stopSec;

		SimController.instance.setStatePlay();
		newPosition = model.getNewPosition();
		setMoveAnim();
	}


	void checkTimeStop(){
		if(scroll.value*maxlenght>=stopTimeToSec && SimController.instance.getState().Equals("play")){
			SimController.instance.setStateStandBy();
			model.GetComponent<Rigidbody>().velocity = Vector3.zero;
			model.GetComponent<UnityAnimationRecorder>().StopRecording();
			isPreview = false;
		}
	}

	void setMoveAnim(){
		Vector3 oldPosition = model.getOldPosition();

		float deltaTime = stopTimeToSec - startTimeToSec;

		model.GetComponent<Transform>().position = oldPosition;

		Vector3 velocity = new Vector3();
		velocity.x = (newPosition.x - oldPosition.x) / deltaTime;
		velocity.y = (newPosition.y - oldPosition.y) / deltaTime;
		velocity.z = (newPosition.z - oldPosition.z) / deltaTime;
		modelVelocity = velocity;

		isPreview =true;

		name = "Move" + Mathf.RoundToInt(Mathf.Abs(oldPosition.x*10))+Mathf.RoundToInt(oldPosition.y*10)+Mathf.RoundToInt(oldPosition.z*10)+
			Mathf.RoundToInt(newPosition.x*10)+Mathf.RoundToInt(newPosition.y*10)+Mathf.RoundToInt(newPosition.z*10);

		model.GetComponent< UnityAnimationRecorder>().SetFileName(name);
		model.GetComponent< UnityAnimationRecorder>().StartRecording();
	}

	public void setClickMoveForPopUp(){
		model.setIsClickmoveForPopUp();
	}

	void moveModelinPreview(){
        if (!isPreview)
        {
            previewBar = GameObject.Find("PreviewBar");

            previewBar.gameObject.SetActive(false);
            return;
        }

		model.GetComponent<Transform>().Translate(modelVelocity * Time.deltaTime);
	}
}
