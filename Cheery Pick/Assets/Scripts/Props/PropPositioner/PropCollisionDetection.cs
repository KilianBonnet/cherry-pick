using UnityEngine;

public class PropCollisionDetection : MonoBehaviour
{
    public bool CanBePlaced { get; private set; }
    private Outline _outline;

    private static readonly Color _CollidedColor = Color.red;
    private static readonly Color _NonCollidedColor = Color.green;

    private void Start()
    {
        _outline = gameObject.GetComponent<Outline>();
        _outline.enabled = true;
        _outline.OutlineColor = _NonCollidedColor;
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.collider.CompareTag("Layout") && !other.collider.CompareTag("Prop"))
            return;

        CanBePlaced = false;
        _outline.OutlineColor = _CollidedColor;
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.collider.CompareTag("Layout") && !other.collider.CompareTag("Prop"))
            return;

        CanBePlaced = true;
        _outline.OutlineColor = _NonCollidedColor;
    }

    private void OnDestroy()
    {
        _outline.enabled = false;
    }
}
