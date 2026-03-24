using UnityEngine;
using UnityEngine.Android;

public class GesturePermissionHandler : MonoBehaviour
{
    public PlayButton playButton;
    public GameObject permissionOverlay;

    public void OnPlayGestureClicked()
    {
#if UNITY_ANDROID

        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            playButton.StartGame();
        }
        else
        {
            Permission.RequestUserPermission(Permission.Camera);
            Invoke(nameof(CheckPermission), 0.5f);
        }

#else
        playButton.StartGame();
        //CheckCameraForPC();
#endif
    }

    void CheckPermission()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            playButton.StartGame();
        }
        else
        {
            ShowOverlay();
        }
    }

    void ShowOverlay()
    {
        permissionOverlay.SetActive(true);
        Invoke(nameof(HideOverlay), 2f);
    }

    void HideOverlay()
    {
        permissionOverlay.SetActive(false);
    }

   /* void CheckCameraForPC()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            ShowOverlay();
            return;
        }

        WebCamTexture cam = new WebCamTexture();
        cam.Play();

        StartCoroutine(CheckCameraWorking(cam));
    }

    System.Collections.IEnumerator CheckCameraWorking(WebCamTexture cam)
    {
        yield return new WaitForSeconds(1f);

        if (!cam.isPlaying || cam.width < 100)
        {
            ShowOverlay(); // camera blocked / denied
        }
        else
        {
            playButton.StartGame(); // camera works ✅
        }
    }*/
}
