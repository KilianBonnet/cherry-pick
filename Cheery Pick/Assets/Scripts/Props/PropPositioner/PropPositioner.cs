
using UnityEngine;

public class PropPositioner : MonoBehaviour
{
    private PropMapper _propMapper;

    // Current Prop
    private GameObject _propToPlace = null;
    private PropCollisionDetection _propCollisionDetection;

    private void Start()
    {
        _propMapper = FindObjectOfType<PropMapper>();
        PositionProp(PropEnum.TEST_PROP);
    }

    /// <summary>
    /// Start the positioning behaviour.
    /// </summary>
    /// <param name="propToPlace">The PropEnum to place.</param>
    public void PositionProp(PropEnum propToPlace)
    {
        _propToPlace = Instantiate(_propMapper.FindPrefab(propToPlace));

        _propCollisionDetection = _propToPlace.AddComponent<PropCollisionDetection>();
        _propToPlace.layer = 2; // "Removing Raycast Layer"
    }

    private void LateUpdate()
    {
        if (_propToPlace == null)
            return;

        TryUpdatePropPosition();

        if (Input.GetMouseButtonDown(0))
            TryPlaceProp();
    }

    private void TryUpdatePropPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the raycast collide with the Floor.
        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.CompareTag("Floor"))
        {
            _propToPlace.SetActive(true);

            // Place the prop where the raycast hit with the Floor.
            Bounds bounds = _propToPlace.GetComponent<Renderer>().bounds;
            float height = bounds.size.y;
            _propToPlace.transform.position = hitInfo.point + new Vector3(0, height / 2, 0);
        }
        else
            _propToPlace.SetActive(false);
    }

    private void TryPlaceProp()
    {
        if (!_propToPlace.activeSelf || !_propCollisionDetection.CanBePlaced)
            return;

        Destroy(_propCollisionDetection);
        _propToPlace.layer = 0; // "Default Layer"
        _propToPlace = null;
    }
}
