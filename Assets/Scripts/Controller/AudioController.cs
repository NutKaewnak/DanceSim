using UnityEngine;
using System.Collections;
using UnityEditor;

public class AudioController : MonoBehaviour {
	
	public static AudioController instance;

	AudioSource[] audioArr;
	Hashtable audioHashTable;

	void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            if (instance != this) {
                Destroy(this);
            }
        }
    }

	void Start () {
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
		audioHashTable = new Hashtable ();
		updateHash ();
	}

	void Update () {
		
	}

	public void updateHash () {
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
		audioHashTable = new Hashtable ();
		Debug.Log ("updateHash");
		foreach (AudioSource audio in audioArr) {
			Debug.Log (audio);
			audioHashTable.Add(audio.name, audio);
		}
	}

	public void playAtTime (string audioName, float time) {
		if (SimController.instance.isStatePlay()) {
			AudioSource audio = audioHashTable [audioName] as AudioSource;
			if (!audio.isPlaying) {
				audio.time = Mathf.Min (time, audio.clip.length - 0.01f);
				audio.Play ();
			}
		}
	}

	public void stop (string audioName) {
		AudioSource audio = audioHashTable [audioName] as AudioSource;
		if (audio.isPlaying) {
			audio.Stop ();
		}
	}

	public float getAudioLengthByName (string audioName) {
		Debug.Log (audioName);
		AudioSource audio = audioHashTable [audioName] as AudioSource;
		return audio.clip.length;
	}

	public void addAudioClip (string path) {
		GameObject audioObject = new GameObject ();
		audioObject.transform.parent = this.gameObject.transform;
		WWW www = new WWW ("file:///" + path);
		Debug.Log (path);
		string[] path_split = path.Split ("/"[0]);
		string	audioName = path_split [path_split.Length - 1];
		audioObject.name = audioName;
		audioObject.AddComponent<AudioSource> ();
		audioObject.GetComponent<AudioSource> ().clip = www.GetAudioClip(false, true);
		audioObject.GetComponent<AudioSource> ().playOnAwake = false;
		updateHash ();
//		Invoke ("updateHash", 1f);
//		Instantiate (audioObject, this.gameObject.transform);
	}

}