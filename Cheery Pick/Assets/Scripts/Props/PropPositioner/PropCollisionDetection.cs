using cakeslice;
using UnityEngine;

public class PropCollisionDetection : MonoBehaviour
{
    public bool CanBePlaced { get; private set; }
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _outline.eraseRenderer = false;
        _outline.color = 1;
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.collider.CompareTag("Layout") && !other.collider.CompareTag("Prop"))
            return;

        CanBePlaced = false;
        _outline.color = 0;
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.collider.CompareTag("Layout") && !other.collider.CompareTag("Prop"))
            return;

        CanBePlaced = true;
        _outline.color = 1;
    }

    private void OnDestroy()
    {
        _outline.eraseRenderer = true;
    }
}
