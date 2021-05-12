//Script for main menu

using UnityEngine;
using System.Collections;

public class menuMain : MonoBehaviour {

	public float areaWidth, areaHeight;

	//Buttons placement and skin
	public GUISkin btnDragOnSkin,btnOptionsSkin,btnExitSkin;
	public float btnX,btnY,btnWidth,btnHeight,offsetX,offsetY,offsetYTwo;

	//Scene switching using multiple cameras
	public GameObject camSlctLvl,confirmationDialogue,menuOptions,menuSound;

	public AudioClip audioBtnPress;

	void Start()
	{
		Time.timeScale=1;
		confirmationDialogue.SetActive(false);
		camSlctLvl.gameObject.SetActive(false);
		//menuOptions.SetActive(false);
		//menuSound.SetActive(false);
	}

	void OnGUI()
	{
		float areaX=(float)Screen.width/800f;
		float areaY=(float)Screen.height/400f;
		GUI.matrix=Matrix4x4.TRS(new Vector3(0f,0f,0f),Quaternion.identity,new Vector3(areaX,areaY,1f));

		//DragOn Game -Takes to the level selection menu.
		GUI.skin=btnDragOnSkin;
		if(GUI.Button(new Rect(btnX,btnY,btnWidth,btnHeight),""))
		{
			audio.PlayOneShot(audioBtnPress);
			Invoke("loadNextMenu",0.12f);
			if(confirmationDialogue)
				confirmationDialogue.SetActive(false);
		}

		//Options -Takes to options menu
		GUI.skin=btnOptionsSkin;
		if(GUI.Button(new Rect(btnX,btnY+offsetY,btnWidth,btnHeight),""))
		{
			audio.PlayOneShot(audioBtnPress);
			if(confirmationDialogue)
				confirmationDialogue.SetActive(false);
			Invoke("loadOptionsMenu",0.12f);
		}
		GUI.skin=null;


		//Exit Button -Exits the application
		GUI.skin=btnExitSkin;
		if(GUI.Button(new Rect(btnX,btnY+offsetYTwo,btnWidth,btnHeight),""))
		{
			audio.PlayOneShot(audioBtnPress);
			confirmationDialogue.gameObject.SetActive(true);
		}
		GUI.skin=null;
	}

	void loadNextMenu()
	{
		transform.parent.gameObject.SetActive(false);
		camSlctLvl.gameObject.SetActive(true);
	}

	void loadOptionsMenu()
	{
		menuOptions.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
