using System;
using System.Linq;
using UnityEngine;

public class PropInteractable : MonoBehaviour
{
    private bool _isSelected;
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
    }

    private void OnMouseDown()
    {
        UnselectOtherInteractables();
        Select();
    }

    private void UnselectOtherInteractables()
    {
        FindObjectsOfType<PropInteractable>()
            .ToList()
            .FindAll(interactor => interactor._isSelected)
            .ForEach(interactor => interactor.Deselect());
    }

    private void Select()
    {
        _isSelected = true;
        _outline.enabled = true;
        _outline.OutlineColor = Color.blue;
    }


    private void Deselect()
    {
        _isSelected = false;
        _outline.enabled = false;
    }

}
