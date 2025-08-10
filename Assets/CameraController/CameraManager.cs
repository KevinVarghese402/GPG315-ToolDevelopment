using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public CustomCameraController camController;
    
    [SerializeField] private Transform cameraTransform;
    
    [Header("Offsets of Each Camera")]
    public Vector3 followCameraOffset = new Vector3(0, 5, -10);
    public Vector3 TopDownCameraOffset = new Vector3(10, 5, -10);
    public Vector3 SideScollerCameraOffset = new Vector3(25, 5, -10);
    public Vector3 firstPersonViewOffset = new Vector3(0, 15 -10);
  
    [Header("Rotations for Each Camera Mode")]
    public Vector3 followRotation = new Vector3(10, 0, 0);
    public Vector3 topDownRotation = new Vector3(90, 0, 0);
    public Vector3 sideScrollerRotation = new Vector3(15, 90, 0);
    public Vector3 firstPersonViewRotation = new Vector3(10, 0, 0);
    
    [Header("Camera Effects Values")] 
    public float mangitudeValue;
    public float durationValue;
    
    public Transform dollyTarget; 
    public float dollySpeed = 2f;
    public enum CustomCameraMode
    {
        Follow,
        TopDown,
        SideScoller,
        FirstPersonView,
        //effects
        CameraShake,
        CameraDolly
    }

    public void SetCameraMode(int modeIndex)
    {
        CustomCameraMode mode = (CustomCameraMode)modeIndex;

        switch (mode)
        {
            case CustomCameraMode.Follow:
                camController.offset = followCameraOffset;
                camController.SetRotation(followRotation);
                camController.SetLockToTarget(false);
                break;;
            
            case CustomCameraMode.TopDown:
                camController.offset = TopDownCameraOffset;
                camController.SetRotation(topDownRotation);
                camController.SetLockToTarget(false);
                break;
            
            case CustomCameraMode.SideScoller:
                camController.offset = SideScollerCameraOffset;
                camController.SetRotation(sideScrollerRotation);
                camController.SetLockToTarget(false);
                break;
            
            case CustomCameraMode.FirstPersonView:
                camController.offset = firstPersonViewOffset;
                camController.SetRotation(firstPersonViewRotation);
                camController.SetLockToTarget(true);
                break;
            
            case CustomCameraMode.CameraShake: 
                CameraShakeEffect(durationValue, mangitudeValue);
                break;
            
            case CustomCameraMode.CameraDolly:
                StartCoroutine(CameraDollyEffect(dollyTarget, dollySpeed));
                break;
            
        
                
        }
    }
    
    
    public void CameraShakeEffect(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 originalPos = cameraTransform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraTransform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }
    
    private IEnumerator CameraDollyEffect(Transform target, float speed)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        Vector3 endPos = target.position;
        Quaternion endRot = target.rotation;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, time);
            transform.rotation = Quaternion.Lerp(startRot, endRot, time);
            yield return null;
        }
    }
    
    
}
