using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	public GameObject pitagoraObjectRoot;

	public static int WIDTH  = 40;
	public static int HEIGHT = 20;

	static bool[,] stage;

	void Start () {
		stage = new bool[WIDTH, HEIGHT];
	}
	
	void Update () {
		
	}

  public GameObject PitagoraInstantiate(GameObject pObject, Vector3 pos) {
    return Instantiate(pObject, pos, Quaternion.identity);
  }

  public GameObject PitagoraInstantiate(GameObject pObject, Vector3 pos, Quaternion quatarnion) {
    var childObject = (GameObject)Instantiate(pObject, pos, quatarnion);
		childObject.transform.parent = pitagoraObjectRoot.transform;
		return childObject;
	}

	public static bool SetObject(Vector2 pos) {
   		int _indexX = (int)pos.x + WIDTH / 2;
    	int _indexY = (int)pos.y + HEIGHT / 2;

    	if(StageManager.stage[_indexX, _indexY]) {
    		return false;
    	}

    	StageManager.stage[_indexX, _indexY] = true;
    	return true;
	}

	public static void RemoveObject(Vector2 pos) {
		int _indexX = (int)pos.x + WIDTH / 2;
    	int _indexY = (int)pos.y + HEIGHT / 2;

    	StageManager.stage[_indexX, _indexY] = false;
	}
}
