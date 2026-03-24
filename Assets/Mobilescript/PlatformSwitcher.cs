using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlatformSwitcher : MonoBehaviour
{
    public bool forceMobileInEditor = false;
    public GameObject mobileUI;
    public PlayerInput playerInput;
    public StarterAssetsInputs starterInputs;

    void Start()
    {
        bool isMobile = Application.isMobilePlatform;
        #if UNITY_EDITOR
            if (forceMobileInEditor) isMobile = true;
        #endif

        // Mobile UI
        if (mobileUI != null)
            mobileUI.SetActive(isMobile);

        // PlayerInput (PC controls)
        if (playerInput != null)
            playerInput.enabled = !isMobile;

        // Cursor settings
        if (starterInputs != null)
        {
            starterInputs.cursorLocked = !isMobile;          // PC = true, Mobile = false
            starterInputs.cursorInputForLook = !isMobile;    // PC = true, Mobile = false
        }

        if (!isMobile)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
