using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour 
{
	Image uiImage;
	Canvas parentCanvas;

	[SerializeField]
	Sprite[] images; // Pictures we want to cycle through

	[SerializeField]
	bool clickToProceed;

	[SerializeField]
	float fadeTime; // amount of time it takes to fade an image

	[SerializeField]
	float displayTime; // amount of time a non-transparent image displays before fading out

	[SerializeField]
	float transparentTime; // amount of time an image stays transparent before fading in

	void Start () 
	{
		parentCanvas = GetComponent<Canvas>();

		if(parentCanvas.worldCamera != Camera.main)
			parentCanvas.worldCamera = Camera.main;

		uiImage = GetComponentInChildren<Image>();

		uiImage.sprite = images[0];

		StartCoroutine(CycleImages());

	}

	void Update () 
	{
		
	}
		
	IEnumerator CycleImages()
	{
		if(!clickToProceed)
		{
			for(int i = 0; i < images.Length; i++)
			{
				uiImage.sprite = images[i];
				uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, 0);

				yield return new WaitForSeconds(transparentTime);

				//Fade in for loop
				for(float alpha = 0; alpha < 1; alpha += Time.deltaTime / fadeTime)
				{
					uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, alpha);

					yield return null; // Wait for frame then return to execution
				}

				yield return new WaitForSeconds(displayTime);

				//Fade out for loop
				for(float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
				{
					uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, alpha);

					yield return null; // Wait for frame then return to execution
				}
			}

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		}
		else
		{
			for(int i = 0; i < images.Length; i++)
			{
				uiImage.sprite = images[i];
				uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, 0);

				yield return new WaitForSeconds(transparentTime);

				//Fade in for loop
				for(float alpha = 0; alpha < 1; alpha += Time.deltaTime / fadeTime)
				{
					uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, alpha);

					yield return null; // Wait for frame then return to execution
				}

				yield return StartCoroutine(WaitForMouseClick());

				//Fade out for loop
				for(float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
				{
					uiImage.color = new Color(uiImage.color.r, uiImage.color.g, uiImage.color.b, alpha);

					yield return null; // Wait for frame then return to execution
				}
			}

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


		}

	}

	IEnumerator WaitForMouseClick()
	{
		while(!Input.GetMouseButton(0))
			yield return null;
	}
}
