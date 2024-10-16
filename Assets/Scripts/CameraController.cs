using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float zoomSpeed = 10f;
    public float moveSpeed = 0.1f;
    public float rotationSpeed = 5f;
    public Vector3 offset;

    private Vector3 lastMousePosition;
    private float lastClickTime = 0f;
    private float catchTime = 0.3f;

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void Update()
    {
        MoveCamera();
        ZoomCamera();
        if (target != null)
        {
            RotateAroundTarget();
        }
        DetectDoubleClick();
    }
    void MoveCamera()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            Vector3 moveDirection = new Vector3(-deltaMouse.x, -deltaMouse.y, 0) * moveSpeed;
            transform.Translate(moveDirection, Space.Self);
        }
        lastMousePosition = Input.mousePosition;
    }
    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * zoomSpeed, Space.Self);
    }
    void RotateAroundTarget()
    {
        if (Input.GetMouseButton(1))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
            float vertical = -Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.RotateAround(target.position, Vector3.up, horizontal);
            transform.RotateAround(target.position, transform.right, vertical);
            offset = transform.position - target.position;
        }
    }
    void FocusOnTarget()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
    void DetectDoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < catchTime)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.GetComponent<ChangableObject>() != null)
                    {
                        target = hit.transform;
                        offset = transform.position - target.position;
                        FocusOnTarget();
                    }
                    
                }
            }
            lastClickTime = Time.time;
        }
    }
}