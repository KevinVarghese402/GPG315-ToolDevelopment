using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (cam.orthographic)
        {
            // Orthographic zoom
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
        else
        {
            // Perspective zoom
            cam.fieldOfView -= scroll * zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        }
    }
}
