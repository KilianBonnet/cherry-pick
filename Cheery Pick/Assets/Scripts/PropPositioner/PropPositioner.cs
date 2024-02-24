
using UnityEngine;

public class PropPositioner : MonoBehaviour
{
    public GameObject PropTest;
    private GameObject _propToPlace = null;

    private void Start()
    {
        PlaceProp(PropsEnum.FUTON);
    }

    public void PlaceProp(PropsEnum propToPlace)
    {
        _propToPlace = Instantiate(PropTest);

        _propToPlace.AddComponent<PropCollisionDetection>();
        _propToPlace.layer = 2; // "Removing Raycast Layer"
    }

    private void LateUpdate()
    {
        if (_propToPlace == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.CompareTag("Floor"))
        {
            _propToPlace.SetActive(true);
            Bounds bounds = _propToPlace.GetComponent<Renderer>().bounds;
            float height = bounds.size.y;
            _propToPlace.transform.position = hitInfo.point + new Vector3(0, height / 2, 0);
        }
        else
        {
            _propToPlace.SetActive(false);
        }
    }
}
