using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public CustomCameraController camController;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Camera mainCamera;
    
    public enum GameDimension { TwoD, ThreeD }
    public GameDimension gameDimension = GameDimension.ThreeD;
    
    [Header("Offsets of Each Camera 3D")]
    public Vector3 followCameraOffset = new Vector3(0, 5, -10);
    public Vector3 TopDownCameraOffset = new Vector3(10, 5, -10);
    public Vector3 SideScollerCameraOffset = new Vector3(25, 5, -10);
    public Vector3 firstPersonViewOffset = new Vector3(0, 15, -10);
    
    [Header("Offsets of Each Camera 2D")]
    public Vector3 followCameraOffset2D = new Vector3(-10, 0, 0);
    public Vector3 topDownCameraOffset2D = new Vector3(0, 10, 0);  
    public Vector3 sideScrollerCameraOffset2D = new Vector3(-10, 0, 0); 
    public Vector3 firstPersonViewOffset2D = new Vector3(0, 0, -10); 
  
    [Header("Rotations for Each Camera Mode 3D")]
    public Vector3 followRotation = new Vector3(10, 0, 0);
    public Vector3 topDownRotation = new Vector3(90, 0, 0);
    public Vector3 sideScrollerRotation = new Vector3(15, 90, 0);
    public Vector3 firstPersonViewRotation = new Vector3(10, 0, 0);
    
    [Header("2D Rotations for Each Camera Mode")]
    public Vector3 followRotation2D = new Vector3(10, 0, 0);
    public Vector3 topDownRotation2D = new Vector3(90, 0, 0);
    public Vector3 sideScrollerRotation2D = new Vector3(15, 90, 0);
    public Vector3 firstPersonViewRotation2D = new Vector3(10, 0, 0);
    
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
        CameraShake,
        CameraDolly
    }

    public void SetCameraMode(int modeIndex)
    {
        if (camController == null)
        {
            Debug.LogError("CameraController is not assigned!");
            return;
        }

        camController.SetOrthographic(gameDimension == GameDimension.TwoD);

        Vector3 offset = Vector3.zero;
        Vector3 rotation = Vector3.zero;

        switch ((CustomCameraMode)modeIndex)
        {
            case CustomCameraMode.Follow:
                offset = (gameDimension == GameDimension.TwoD) ? followCameraOffset2D : followCameraOffset;
                rotation = (gameDimension == GameDimension.TwoD) ? followRotation2D : followRotation;
                camController.SetLockToTarget(false);
                break;

            case CustomCameraMode.TopDown:
                offset = (gameDimension == GameDimension.TwoD) ? topDownCameraOffset2D : TopDownCameraOffset;
                rotation = (gameDimension == GameDimension.TwoD) ? topDownRotation2D : topDownRotation;
                camController.SetLockToTarget(false);
                break;

            case CustomCameraMode.SideScoller:
                offset = (gameDimension == GameDimension.TwoD) ? sideScrollerCameraOffset2D : SideScollerCameraOffset;
                rotation = (gameDimension == GameDimension.TwoD) ? sideScrollerRotation2D : sideScrollerRotation;
                camController.SetLockToTarget(false);
                break;

            case CustomCameraMode.FirstPersonView:
                offset = (gameDimension == GameDimension.TwoD) ? firstPersonViewOffset2D : firstPersonViewOffset;
                rotation = (gameDimension == GameDimension.TwoD) ? firstPersonViewRotation2D : firstPersonViewRotation;
                camController.SetLockToTarget(true);
                break;

            case CustomCameraMode.CameraShake:
                CameraShakeEffect(durationValue, mangitudeValue);
                return;

            case CustomCameraMode.CameraDolly:
                StartCoroutine(CameraDollyEffect(dollyTarget, dollySpeed));
                return;
        }

        camController.offset = offset;
        camController.SetRotation(rotation);
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
    
    private IEnumerator CameraDollyEffect(Transform dollyTarget, float speed)
    {
        Vector3 startOffset = camController.offset;
        Vector3 targetOffset = dollyTarget.position - camController.target.position; 
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            camController.offset = Vector3.Lerp(startOffset, targetOffset, time);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * speed;
            camController.offset = Vector3.Lerp(targetOffset, startOffset, time);
            yield return null;
        }
    }
}
