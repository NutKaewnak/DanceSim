using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockManager : MonoBehaviour {

	public abstract float getStartTime ();

	public abstract float getHandleStart ();

	public abstract void setStartTime (float time);

	public abstract void setHandleStart (float x);
}
