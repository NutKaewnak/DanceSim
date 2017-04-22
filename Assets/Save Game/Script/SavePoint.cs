using UnityEngine;
using System.Collections;
using System;
using System.IO;

// an interactable save point. 
public class SavePoint : MonoBehaviour, IInteractable
{
    public event Action<IInteractable> InteractionOccurred;
    private bool inProgress;

    [SerializeField]
    private string locationName;     

    public IEnumerator Interact()
    {        
        this.inProgress = true;
        Player.Instance.MovementController.enabled = false;        
        string screenShot = Path.Combine(Application.persistentDataPath, "tmpScreenshot.png");
        Application.CaptureScreenshot(screenShot); 
        yield return null;
        ScreenManager.Instance.OpenSaveScreen();
        ScreenManager.Instance.SaveGameScreen.AccessedSavePoint = this;

        // wait for save screen to be closed.
        while (ScreenManager.Instance.SaveGameScreen.gameObject.activeInHierarchy)
            yield return null;

        // if the tmpScreenshot still exists get rid of it. 
        if (File.Exists(screenShot))
            File.Delete(screenShot);

        Player.Instance.MovementController.enabled = true;  
        this.inProgress = false;        
    }
    

    public void SetActiveInteraction(bool val)
    {        
    }

    public bool InProgress { get { return this.inProgress; } }
    public string InteractionText { get { return "Press E to Save"; } }
    public bool CanManuallyTrigger { get { return true; } }
    public string LocationName { get { return this.locationName; } }
}
