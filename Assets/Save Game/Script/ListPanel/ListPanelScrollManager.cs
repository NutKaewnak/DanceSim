using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// for automatically scrolling to selected items. Mainly for controller/keyboard focus support
[RequireComponent(typeof(ScrollRect))]
public class ListPanelScrollManager : MonoBehaviour
{        
    private ScrollRect scrollRect; 
    [SerializeField]
    private ListPanel listPanel;         

    void Awake()
    {
        this.scrollRect = this.GetComponent<ScrollRect>();
    }

    void Start()
    {
        if (this.listPanel == null) Debug.LogError("ListPanel not attached.");
        this.listPanel.ItemSelected += ListPanel_ItemSelected;
    }

    void OnDestroy()
    {
        this.listPanel.ItemSelected -= ListPanel_ItemSelected;
    }

    private void ListPanel_ItemSelected(GameObject selectedItem)
    {        
        if(selectedItem != null && this.scrollRect != null)
        {     
            float scrollPercentage = selectedItem.transform.localPosition.y / (this.scrollRect.viewport.rect.height - this.scrollRect.content.rect.height);         
                      
            float normalizedPercentage = 1 - scrollPercentage - (scrollPercentage / this.scrollRect.viewport.rect.height);                 
            // 0 is the bottom of content, 1 is the top.         
            this.scrollRect.verticalNormalizedPosition = Mathf.Clamp01(normalizedPercentage);
        }        
    }
}
