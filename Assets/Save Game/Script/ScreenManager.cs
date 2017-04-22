using UnityEngine;
using System.Collections;

// simple mechanism for opening the save or load game screens. 
public class ScreenManager : MonoBehaviour
{
    #region Singleton
    private static ScreenManager instance;
    public static ScreenManager Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    private SaveGameController saveGameScreen;

    public SaveGameController SaveGameScreen { get { return this.saveGameScreen; } }

    public void OpenLoadScreen()
    {
        this.saveGameScreen.CanSave = false;
        this.saveGameScreen.gameObject.SetActive(true);
    }

    public void OpenSaveScreen()
    {
        this.saveGameScreen.CanSave = true;
        this.saveGameScreen.gameObject.SetActive(true);
    }

    public void CloseSaveScreen()
    {
        this.saveGameScreen.gameObject.SetActive(false);
    }

}
