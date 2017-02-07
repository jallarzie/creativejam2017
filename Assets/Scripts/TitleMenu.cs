﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class TitleMenu : MonoBehaviour {

	[SerializeField]
	private Animator canvasAnimator;
	[SerializeField]
	private GameObject pressToPlay;
	[SerializeField]
	private GameObject instructions;
	[SerializeField]
	private GameObject title;
	[SerializeField]
	private GameObject selectionScreen;
	[SerializeField]
	private GameObject[] p1Selection;
	[SerializeField]
	private GameObject[] p2Selection;
	[SerializeField]
	private GameObject[] p3Selection;
	[SerializeField]
	private GameObject[] p4Selection;
	[SerializeField]
	private GameObject[] cursors;

	private List<GameObject[]> pSelection;
	private int count;

	public void Start(){
        pSelection = new List<GameObject[]>();
		pSelection.Add(p1Selection);
        pSelection.Add(p2Selection);
        pSelection.Add(p3Selection);
        pSelection.Add(p4Selection);
        count = 0;
	}

	public void LoadScene(string loadedScene){
		SceneManager.LoadScene (loadedScene, LoadSceneMode.Single);
	}

	public void showInstructions(){
		canvasAnimator.Stop ();
		pressToPlay.SetActive (false);
		title.SetActive (false);
		instructions.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.ActiveDevice != null) {
			if (InputManager.ActiveDevice.GetControl (InputControlType.Start)) {
				Application.Quit ();
			}
			if (InputManager.ActiveDevice.AnyButton.WasPressed) {
				if (instructions.activeSelf) {
					instructions.SetActive (false);
					instructions.gameObject.SetActive (false);
					selectionScreen.SetActive (true);
					selectionScreen.gameObject.SetActive (true);
				} else if (selectionScreen.activeSelf) {
					if (InputManager.ActiveDevice.AnyButton.WasPressed) {
						if (count < 4) {
							cursors [0].transform.position = pSelection [0][count].transform.position;
							count++;
						}
					}
				} else {
					showInstructions ();
				}
			}
		}
	}
}
