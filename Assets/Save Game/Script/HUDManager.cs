using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    #region Singleton
    private static HUDManager instance;
    public static HUDManager Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    private Text txtPrompt;
    [SerializeField]
    private Text txtNotificationText; 

    public void ShowPromptText(bool val)
    {
        if(this.txtPrompt != null)
            this.txtPrompt.gameObject.SetActive(val);
    }

    public void SetPromptText(string text)
    {
        if(this.txtPrompt != null)
            this.txtPrompt.text = text;
    }

    public void ShowNotification(string text)
    {
        if (this.txtNotificationText != null)
        {
            this.txtNotificationText.text = text;
            this.txtNotificationText.gameObject.SetActive(true);
            this.Invoke("HideNotification", 1);
        }
    }

    private void HideNotification()
    {
        if(this.txtNotificationText != null)
            this.txtNotificationText.gameObject.SetActive(false);
    }

}
