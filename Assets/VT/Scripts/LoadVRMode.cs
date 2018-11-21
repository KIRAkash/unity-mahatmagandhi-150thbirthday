using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.VR;
using UnityEngine.SceneManagement;

public class LoadVRMode : MonoBehaviour
{

	//Starting VR mode
	void Start()
	{
		StartCoroutine(SwitchToVR());
	}

	// Call via `StartCoroutine(SwitchToVR())` from your code. Or, use
	// `yield SwitchToVR()` if calling from inside another coroutine.
	IEnumerator SwitchToVR() {
		// Device names are lowercase, as returned by `XRSettings.supportedDevices`.
		string desiredDevice = "cardboard"; // Or "daydream".

		XRSettings.LoadDeviceByName(desiredDevice);

		// Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
		yield return null;

		// Now it's ok to enable VR mode.
		XRSettings.enabled = true;
	}


	//Exiting VR mode using back button or X button on the top left corner
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Android close icon or back button tapped.
			//Application.Quit();
			SceneManager.LoadScene(0);
			StartCoroutine(SwitchTo2D());
		}
	}



	// Call via `StartCoroutine(SwitchTo2D())` from your code. Or, use
	// `yield SwitchTo2D()` if calling from inside another coroutine.
	IEnumerator SwitchTo2D() {
		// Empty string loads the "None" device.
		XRSettings.LoadDeviceByName("");

		// Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
		yield return null;

		// Not needed, since loading the None (`""`) device takes care of this.
		// XRSettings.enabled = false;

		// Restore 2D camera settings.
		ResetCameras();
	}

	// Resets camera transform and settings on all enabled eye cameras.
	void ResetCameras() {
		// Camera looping logic copied from GvrEditorEmulator.cs
		for (int i = 0; i < Camera.allCameras.Length; i++) {
			Camera cam = Camera.allCameras[i];
			if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {

				// Reset local position.
				// Only required if you change the camera's local position while in 2D mode.
				cam.transform.localPosition = Vector3.zero;

				// Reset local rotation.
				// Only required if you change the camera's local rotation while in 2D mode.
				cam.transform.localRotation = Quaternion.identity;

				// No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
				// cam.ResetAspect();

				// No need to reset `fieldOfView`, since it's reset automatically.
			}
		}
	}

}