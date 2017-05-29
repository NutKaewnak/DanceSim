using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.ComponentModel;
using UnityEngine.EventSystems;
using System;

// ui class to deal with standard item selection and clicking behavior. Why unity doesn't support this by default... 
public class ListPanel : MonoBehaviour, INotifyItemSelected
{    
    // todo: check if gamepad submit press on selected button fires the click event, and if so use this to fire an event up for the 
    // screen controller. note that I'll have to rewire some stuff in regards to the update in the SectionfocusController to not move focus
    // on submit...

    public event Action<GameObject> ItemCreated; 
    public event Action<GameObject> ItemSelected; 
    public event Action<GameObject> ItemPressed;    

    [SerializeField] private GameObject itemPrefab;        
    
    private EventTrigger.Entry itemSelected; 
    protected GameObject lastSelectedItem; 

    protected virtual void Start()
    {
        if (this.itemPrefab == null) Debug.LogError("ItemPrefab not attached.");        
    }

    public virtual GameObject CreateItem()
    {
        if (this.itemSelected == null)
        {
            this.itemSelected = new EventTrigger.Entry();
            this.itemSelected.eventID = EventTriggerType.Select;
            this.itemSelected.callback.AddListener(this.ItemSelectedHandler);            
        }

        GameObject go = GameObject.Instantiate(this.itemPrefab); 
        EventTrigger et = go.GetComponent<EventTrigger>();        
        if(et != null)
            et.triggers.Add(this.itemSelected);
        Button btn = go.GetComponent<Button>(); 
        if(btn != null)
            btn.onClick.AddListener(ItemClickedHandler);        
        go.transform.SetParent(this.transform); 
        return go; 
    }      

    protected virtual void ItemSelectedHandler(BaseEventData data)
    {
        if(data != null && data.selectedObject != null)
        {
            this.lastSelectedItem = data.selectedObject; 
            this.OnItemSelected(data.selectedObject);
        }
    }

    protected virtual void ItemClickedHandler()
    {        
        this.OnItemPressed(this.lastSelectedItem);
    }

    protected void OnItemCreated(GameObject go)
    {
        Action<GameObject> act = this.ItemCreated; 
        if(act != null)
            act(go);
    }

    protected void OnItemSelected(GameObject go)
    {
        Action<GameObject> act = this.ItemSelected; 
        if(act != null)
            act(go);
    }

    protected void OnItemPressed(GameObject go)
    {
        Action<GameObject> act = this.ItemPressed; 
        if(act != null)
            act(go);
    }

    public void ClearItems()
    {
        this.transform.DestroyAllChildren();
    }

    public void SelectFirstItem()
    {        
        if (this.transform.childCount > 0)
            EventSystem.current.SetSelectedGameObject(this.transform.GetChild(0).gameObject);
    }

    public GameObject SelectedItem { get { return this.lastSelectedItem; } }
}
