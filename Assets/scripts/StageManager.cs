using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	public static int WIDTH  = 40;
	public static int HEIGHT = 20;

	public static bool[,] stage;

	void Start () {
		stage = new bool[WIDTH, HEIGHT];	
	}
	
	void Update () {
		
	}
}
