using System;
using System.Linq;
using cakeslice;
using UnityEngine;

public class PropInteractable : MonoBehaviour
{
    public bool _isSelected;
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
        _outline.eraseRenderer = false;
        _outline.color = 2;
    }


    private void Deselect()
    {
        _isSelected = false;
        _outline.eraseRenderer = true;
    }

}
