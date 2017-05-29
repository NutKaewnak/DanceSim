using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

// checks for button presses and triggers the active interaction. 
public class PlayerInteractionController : MonoBehaviour
{    
    private Coroutine interactionCoroutine; 
    private bool canInteract = false; 
    private IEnumerable<IInteractable> interactables; 

    private void OnEnable()
    {        
        if(this.interactables != null)
        {
            foreach(IInteractable interactable in this.interactables)
            {
                if(!string.IsNullOrEmpty(interactable.InteractionText))
                {
                    HUDManager.Instance.SetPromptText(interactable.InteractionText);
                    HUDManager.Instance.ShowPromptText(true);                    
                    break;
                }
            }
        }        
        this.InvokeRepeating("CanInteract", 0, .5f); 
    }

    private void OnDisable()
    {
        HUDManager.Instance.ShowPromptText(false);
        this.CancelInvoke("CanInteract");
    }

    private void Update()
    {
        if (this.canInteract && Input.GetKeyUp(KeyCode.E))
            this.Interact();                    
    }

    private void Interact()
    {
        this.canInteract = false; 
        foreach(IInteractable interactable in this.interactables)        
            this.StartCoroutine(interactable.Interact());        
    }

    private void CanInteract()
    {
        if(this.interactables != null)
        {
            foreach(IInteractable interactable in this.interactables)
            {
                if(interactable == null || interactable.InProgress)
                {
                    this.canInteract = false;                    
                    return;
                }
            }
        }        
        this.canInteract = true; 
    }

    public void SetInteractables(IEnumerable<IInteractable> items)
    {
        this.canInteract = false;        
        this.interactables = items;                 
    }
}
