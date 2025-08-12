using UnityEngine;
using System.Collections;
public class CustomCameraController : MonoBehaviour
{
    [Header("Camera Target Settings")]
    public Transform target; // the target the camera will follow
    
    [Header("Camera Follow Settings")]
    public Vector3 offset = new Vector3(); 
    public float followSpeed = 5f; // How smooth the follow is
    
    [Header("Camera Orthographic Settings")]
    public Camera mainCamera;
    public bool startAsOrthographic = false;
    
    [Header("Camera Boundaries Settings")] 
    public bool useBoundaries = false;
    public Vector2 minimalBound;
    public Vector2 maxiBound;
    private Camera cam; 
    
    [Header("Camera Locked Positions")]
    private bool lockToTarget = false;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        
        if (mainCamera == null)
        {
         mainCamera = cam;
        }

        if (mainCamera != null)
        {
         mainCamera.orthographic = startAsOrthographic;
        }

    }
    

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;
        
        if (lockToTarget == true)
        {
            transform.position = target.position + offset;
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;

            if (useBoundaries)
            {
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minimalBound.x, maxiBound.x);
                desiredPosition.y = Mathf.Clamp(desiredPosition.y, minimalBound.y, maxiBound.y);
            }
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
        
    }
    public void SetRotation(Vector3 newRotation)
    {
        transform.rotation = Quaternion.Euler(newRotation);
    }
    
    public void SetLockToTarget(bool shouldLock)
    {
        lockToTarget = shouldLock;
    }
    
    public void SetOrthographic(bool isOrtho) 
    {
        if (mainCamera != null)
            mainCamera.orthographic = isOrtho;
        
    }
 


}
