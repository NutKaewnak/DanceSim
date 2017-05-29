using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// allows scroll events to bubble up the event tree to the scroll rect. Normally scrolling on the list item will capture the event and prevent
// the scroll wheel interaction from reacting the scroll rect unless the player scrolls on some unoccupied margin area.
public class ScrollEventPassThrough : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    private bool parentSearched = false;
    public ScrollRect scrollRect;

    void Awake()
    {
        if (this.transform.parent != null && this.scrollRect == null)
        {
            this.scrollRect = this.transform.GetComponentInAnyParent<ScrollRect>();
            this.parentSearched = true;
        }
    }

    void Update()
    {
        if (!this.parentSearched && this.scrollRect == null && this.transform.parent != null)
        {
            this.scrollRect = this.transform.GetComponentInAnyParent<ScrollRect>();
            this.parentSearched = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.scrollRect != null)
            this.scrollRect.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.scrollRect != null)
            this.scrollRect.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.scrollRect != null)
            this.scrollRect.OnEndDrag(eventData);
    }

    public void OnScroll(PointerEventData data)
    {
        if (this.scrollRect != null)
            this.scrollRect.OnScroll(data);
    }
}