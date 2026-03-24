using UnityEngine;
using StarterAssets;

public class MobileInputBridge : MonoBehaviour
{
    public StarterAssetsInputs starterInput;
    public MobileJoystick joystick;
    public MobileLookArea lookArea;
    public bool testMobileInEditor = false;


    void Update()
    {
        if (starterInput == null) return;
        bool isMobile = Application.isMobilePlatform;

        #if UNITY_EDITOR
            if (testMobileInEditor) isMobile = true;
        #endif
        if (!isMobile) return;

        // LOOK always from LookArea
        if (lookArea != null)
            starterInput.LookInput(lookArea.lookDelta);

        // MOVE only if joystick is being touched
        if (joystick != null)
        {
            if (joystick.isDragging)
                starterInput.MoveInput(joystick.inputVector);
            else
                starterInput.MoveInput(Vector2.zero);
        }
    }
}
