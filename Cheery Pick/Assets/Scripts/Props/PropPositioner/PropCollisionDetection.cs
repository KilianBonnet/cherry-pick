using cakeslice;
using UnityEngine;

public class PropCollisionDetection : MonoBehaviour
{
    public bool CanBePlaced { get; private set; }
    private Outline _outline;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _outline.enabled = true;
        _outline.color = 1;
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.collider.CompareTag("Layout"))
            return;

        CanBePlaced = false;
        _outline.color = 0;
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.collider.CompareTag("Layout"))
            return;

        CanBePlaced = true;
        _outline.color = 1;
    }

    private void OnDestroy()
    {
        _outline.enabled = false;
    }
}
