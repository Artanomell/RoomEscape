﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManagers : MonoBehaviour 
{
	public void OpenScene(string name)
	{
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}