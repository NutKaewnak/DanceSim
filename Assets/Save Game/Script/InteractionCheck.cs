using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

// collider component to see if the interaction is accessible based on the players position and look direction
public class InteractionCheck : MonoBehaviour
{
    private List<IInteractable> interactables;
    private bool checkAngle = false;
    private bool activeState = false;

    void Start()
    {
        this.interactables = new List<IInteractable>();
        this.FindValidInteractables();
        this.SetInteractablesActive(false);        
    }

    private void FindValidInteractables()
    {      
        IInteractable[] items = this.GetComponentsInParent<IInteractable>();
        if (items != null && items.Length > 0)
        {
            this.interactables = items.Where(x => x.CanManuallyTrigger).ToList();
            if (this.interactables != null && this.interactables.Count > 0)
            {
                foreach (IInteractable interactable in this.interactables)            
                    interactable.InteractionOccurred += Interactable_InteractionOccurred;            
            }
        }
    }

    private void RemoveTriggeredInteractables()
    {        
        for (int i = this.interactables.Count - 1; i >= 0; i--)
        {
            if (!this.interactables[i].CanManuallyTrigger)
                this.interactables.RemoveAt(i);
        }
    }

    private void Interactable_InteractionOccurred(IInteractable obj)
    {
        this.DeactivateInteraction();
        this.RemoveTriggeredInteractables();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            this.checkAngle = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            this.DeactivateInteraction();
            this.checkAngle = false;
        }
    }

    void Update()
    {
        if (this.checkAngle)
        {
            float angle = Vector3Helper.GetAngleInRadians(Player.Instance.transform.forward, this.transform.position - Player.Instance.transform.position, Vector3.up);            
            if (Mathf.Abs(angle) < MathConstants.Rad15Deg)
                this.ActivateInteraction();
            else
                this.DeactivateInteraction();
        }
    }

    private void ActivateInteraction()
    {
        if (!this.activeState)
        {
            this.SetInteractablesActive(true);
            Player.Instance.InteractionController.SetInteractables(interactables);
            Player.Instance.InteractionController.enabled = true;
            this.activeState = true;            
        } 
    }

    private void DeactivateInteraction()
    {
        if (this.activeState)
        {
            this.SetInteractablesActive(false);
            Player.Instance.InteractionController.enabled = false;
            Player.Instance.InteractionController.SetInteractables(null);
            this.activeState = false;
        }
    }

    private void SetInteractablesActive(bool val)
    {
        if (this.interactables != null)
            foreach (IInteractable interaction in this.interactables)
                interaction.SetActiveInteraction(val);
    }
}
