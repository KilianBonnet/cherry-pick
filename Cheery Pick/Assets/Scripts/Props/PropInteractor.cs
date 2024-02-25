using System;
using System.Linq;
using cakeslice;
using UnityEngine;

public class PropInteractor : MonoBehaviour
{
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
    }

    private void OnMouseDown()
    {
        _outline.eraseRenderer = false;
        _outline.color = 2;
        UnselectOtherInteractor();
    }

    private void UnselectOtherInteractor()
    {
        // Trouver tous les PropInteractable dans la scène
        PropInteractor[] interactables = FindObjectsOfType<PropInteractor>();

        // Parcourir tous les PropInteractable et les désélectionner
        foreach (PropInteractor interactable in interactables)
        {
            if (interactable != this) // Ne désélectionnez pas celui qui vient d'être cliqué
            {
                interactable.Deselect();
            }
        }
    }

    private void Hey()
    {
        Debug.Log($"Interactor {name}");
    }

    private void Deselect()
    {
        _outline.eraseRenderer = true;
    }

}
