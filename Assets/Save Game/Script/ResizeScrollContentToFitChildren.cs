using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// compliments using a vertical or horizontal layout panel in a scroll view. this lets you better define each items size in a list. 
[RequireComponent(typeof(ScrollRect))]
public class ResizeScrollContentToFitChildren : MonoBehaviour
{
    private ScrollRect scrollRect; 

    [SerializeField]
    private Vector2 childSize;     
    [SerializeField]
    private Vector2 childSpacing; 
    [SerializeField]
    private RectOffset margin; 
    [SerializeField]
    private bool updateHeight; 
    [SerializeField]
    private bool updateWidth; 
    
    private int lastChildCount = 0; 

    void Start()
    {        
        this.scrollRect = this.GetComponent<ScrollRect>();        
    }

    void Update()
    {
        if(this.lastChildCount != this.scrollRect.content.childCount)
        {
            this.StartCoroutine(this.Resize());             
            this.lastChildCount = this.scrollRect.content.childCount;
        }
    }

    IEnumerator Resize()
    {
        if(this.scrollRect.content.childCount > 0)
        {
            // need to wait a frame so the layout can update if this current frame is the one in which the new children were added. 
            yield return null; 
            if(this.updateHeight && this.childSize.y > 0)
            {                
                float newHeight = this.childSize.y * this.scrollRect.content.childCount + (this.childSpacing.y * this.scrollRect.content.childCount - this.childSpacing.y) + this.margin.top + this.margin.bottom;                                
                this.scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);   
                this.scrollRect.verticalNormalizedPosition = 1;              
            }
            if(this.updateWidth && this.childSize.x > 0)
            {
                float newWidth = this.childSize.x * this.scrollRect.content.childCount + (this.childSpacing.x * this.scrollRect.content.childCount - this.childSpacing.x) + this.margin.left +  this.margin.right;                 
                this.scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
                this.scrollRect.horizontalNormalizedPosition = 1; 
            }            
        }
        
    }
}

