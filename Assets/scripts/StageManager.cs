using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

	public static int WIDTH  = 40;
	public static int HEIGHT = 20;

	static bool[,] stage;

	public Material lineMaterial;

	void Start () {
		stage = new bool[WIDTH, HEIGHT];
	}
	
	void Update () {
		
	}

	void OnRenderObject() {
	    lineMaterial.SetPass(0);
	    GL.PushMatrix();
	    GL.MultMatrix(this.transform.localToWorldMatrix);

	    for(int i = 0; i < WIDTH; i++) {
	    	GL.Begin(GL.LINES);
			GL.Vertex3(i - WIDTH / 2, -HEIGHT / 2, 0f);
			GL.Vertex3(i - WIDTH / 2,  HEIGHT / 2, 0f);
			GL.End();
	    }

    	for(int j = 0; j < HEIGHT; j++) {
    		GL.Begin(GL.LINES);
			GL.Vertex3(-WIDTH / 2, j - HEIGHT / 2, 0f);
			GL.Vertex3( WIDTH / 2, j - HEIGHT / 2, 0f);
			GL.End();
    	}

	    GL.PopMatrix();
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
