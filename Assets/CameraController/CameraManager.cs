using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CustomCameraController camController;

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
    public enum CustomCameraMode
    {
        Follow,
        TopDown,
        SideScoller,
        LookAhead
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
            
            case CustomCameraMode.LookAhead:
                camController.offset = firstPersonViewOffset;
                camController.SetRotation(firstPersonViewRotation);
                camController.SetLockToTarget(true);
                break;
        }
    }
}
