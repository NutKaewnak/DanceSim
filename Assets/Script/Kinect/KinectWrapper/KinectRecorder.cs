using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Kinect;
using UnityEngine.UI;

public class KinectRecorder : MonoBehaviour {
	
	public DeviceOrEmulator devOrEmu;
	private KinectInterface kinect;
	
	public string outputFile = "Assets/Recordings/playback";
	
	
	private bool isRecording = false;
	private bool isStopRecord = false;
	private double startTime = 0;
	private ArrayList currentData = new ArrayList();
	
	//add by lxjk
	private int fileCount = Directory.GetFiles(@"Assets/Recordings/", "*", SearchOption.TopDirectoryOnly).Length / 2;
	//end lxjk
	
	
	// Use this for initialization
	void Start () {
		kinect = devOrEmu.getKinect();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isRecording){
			if(Input.GetKeyDown(KeyCode.F10)){
				StartRecord();
			}
		} else {
			if(Input.GetKeyDown(KeyCode.F10)){
				StopRecord();
			}
			if (kinect.pollSkeleton()){
				currentData.Add(kinect.getSkeleton());
			}
		}
		if(isStopRecord){
			if(Time.time > startTime+3){
				isStopRecord = false;
				devOrEmu.enabled = true;
				Debug.Log("stop recording");
			}
		}

	}

	
	public void StartRecord() {
		isRecording = true;
		Debug.Log("start recording");
	}
	
	public void StopRecord() {
		isRecording = false;
		isStopRecord = true;
		//edit by lxjk
		string filePath = outputFile+fileCount.ToString();
		Debug.Log("filepath");
		Debug.Log(filePath);
		FileStream output = new FileStream(@filePath,FileMode.Create);
		//end lxjk
		BinaryFormatter bf = new BinaryFormatter();

        Debug.Log("NUI_SKELETON_DATA.count");
        Debug.Log(currentData.Count);
        Debug.Log(((NuiSkeletonFrame)currentData[41]).liTimeStamp);
        SerialSkeletonFrame[] data = new SerialSkeletonFrame[currentData.Count];
		for(int ii = 0; ii < currentData.Count; ii++){
			data[ii] = new SerialSkeletonFrame((NuiSkeletonFrame)currentData[ii]);
		}
		bf.Serialize(output, data);
		output.Close();
		fileCount++;
		startTime = Time.time;
		devOrEmu.enabled = false;
		
	}
}
