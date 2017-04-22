using UnityEngine;
using System.Collections;
using System;

// interface for defining objects that are interacted with by the player. 
public interface IInteractable
{    
    IEnumerator Interact();
    event Action<IInteractable> InteractionOccurred; 
    void SetActiveInteraction(bool val);
    string InteractionText { get; }
    bool InProgress { get; }
    bool CanManuallyTrigger { get; }
}