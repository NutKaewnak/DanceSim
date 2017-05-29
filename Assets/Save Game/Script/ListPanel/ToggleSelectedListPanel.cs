using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// operates the same as a list panel, but the last pressed item has a separate visual state. more applicable name pending... 
public class ToggleSelectedListPanel : ListPanel
{
    // should these be buttons or can I make a better way to host the ColorBlock style in the editor. 
    // maybe wrap it in another serializable type so I can bind to the source button?
    // TODO: abstract styling logic away to the item prefab so that I dont have prefab specific logic in this control. 

    [SerializeField] private Button normalItemStyle;
    [SerializeField] private Button selectedItemStyle;
    private GameObject lastPressedItem; 

    protected override void Start()
    {
        base.Start();
        if (this.normalItemStyle == null) Debug.LogError("NormalItemStyle not attached.");
        if (this.selectedItemStyle == null) Debug.LogError("SelectedItemStyle not attached.");
    }

    public override GameObject CreateItem()
    {
        GameObject go = base.CreateItem();
        this.ApplyNormalStyle(go);
        return go;
    }

    public void ApplyNormalStyle(GameObject item)
    {
        Button btn = item.GetComponent<Button>(); 
        if(btn != null)
        {
            ColorBlock cb = btn.colors; 
            cb.normalColor = this.normalItemStyle.colors.normalColor;
            cb.highlightedColor = this.normalItemStyle.colors.highlightedColor; 
            cb.disabledColor = this.normalItemStyle.colors.disabledColor; 
            cb.pressedColor = this.normalItemStyle.colors.pressedColor;
            btn.colors = cb; 
        }
    }

    public void ApplySelectedStyle(GameObject item)
    {
        Button btn = item.GetComponent<Button>(); 
        if(btn != null)
        {
            ColorBlock cb = btn.colors; 
            cb.normalColor = this.selectedItemStyle.colors.normalColor;
            cb.highlightedColor = this.selectedItemStyle.colors.highlightedColor; 
            cb.disabledColor = this.selectedItemStyle.colors.disabledColor; 
            cb.pressedColor = this.selectedItemStyle.colors.pressedColor;
            btn.colors = cb; 
        }
    }
    
    protected override void ItemClickedHandler()
    {
        if(this.lastPressedItem != null)
            this.ApplyNormalStyle(this.lastPressedItem); 
        if(this.lastSelectedItem != null)
        {
            this.ApplySelectedStyle(this.lastSelectedItem);
            this.lastPressedItem = this.lastSelectedItem;
        }

        base.ItemClickedHandler();
    }

    public void ResetPressedState()
    {
        if(this.lastPressedItem != null)
        {
            this.ApplyNormalStyle(this.lastPressedItem); 
            this.lastPressedItem = null; 
        }
    }

    public GameObject PressedItem { get { return this.lastPressedItem; } }
}
