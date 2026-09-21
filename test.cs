using System.Diagnostics;
using UnityEngine;
// 1. You MUST add this line at the very top of your script
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    public Transform mesh;
    public WheelCollider wh;

    void FixedUpdate()
    {
        Debug.log("testing...");
        HandleSteering(wh);
        UpdateWheelVisuals(wh, mesh);
    }

    void HandleSteering(WheelCollider collider)
    {
        float steeringInput = 0f;

        // 2. Check if a Keyboard is currently connected/active
        if (Keyboard.current != null)
        {
            // Reads A/D keys or Left/Right Arrow keys (-1 to 1)
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                steeringInput = -1f;
            }
            else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                steeringInput = 1f;
            }
        }

        // 3. Apply steering directly to the physical wheel collider
        collider.steerAngle = steeringInput * 30f;
    }

    void UpdateWheelVisuals(WheelCollider collider, Transform meshTransform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);
        position = transform.position;
        meshTransform.SetPositionAndRotation(position, rotation);
    }
}
