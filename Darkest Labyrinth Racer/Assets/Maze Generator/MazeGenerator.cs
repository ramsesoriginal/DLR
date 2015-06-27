
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour {
	public GameObject[] FrequentTiles;
	public GameObject[] MediumTiles;
	public GameObject[] RareTiles;
	public GameObject[] LeftBorder;
	public GameObject[] RightBorder;
	public GameObject[] TopBorder;
	public GameObject[] BottomBorder;
	public GameObject[] TopLeft;
	public GameObject[] TopRight;
	public GameObject[] BottomLeft;
	public GameObject[] BottomRight;
	public GameObject endTile;
	public int width;
	public int height;
	public float tileSize;

	private GameObject[,] maze;

	void Update() {
		if (Input.GetKeyDown (KeyCode.R))
			Application.LoadLevel (Application.loadedLevelName);
	}

	void Start() {
		Debug.Log(string.Format("Generating maze with size {0},{1}",width,height));
		maze = new GameObject[width,height];
		maze [0,0] = gameObject;
		transform.position = Vector3.zero;
		int endX = (int)((width) / 2);
		int endY = (int)((height) / 2);
		maze [endX,endY] = endTile;
		endTile.transform.position = new Vector3 (endX,0,endY)*tileSize;
		Debug.Log("looping over Tiles");
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Debug.Log(string.Format("Tile {0},{1}",x,y));
				if (maze [x,y] == null) {
					GameObject[] choice;
					if (x == 0) {
						if (y == 0) {
							choice = BottomLeft;
						} else if (y == height-1) {
							choice = TopLeft;
						} else {
							choice = LeftBorder;
						}
					} else if (x == width-1) {
						if (y == 0) {
							choice = BottomRight;
						} else if (y == height-1) {
							choice = TopRight;
						} else {
							choice = RightBorder;
						}
					} else if (y == 0) {
						choice = BottomBorder;
					} else if (y == height-1) {
						choice = TopBorder;
					} else {
						var ranValue = Random.Range(0f,1f);
						if (ranValue < .6f) {
							choice = FrequentTiles;
						} else if (ranValue < .3f) {
							choice = MediumTiles;
						} else {
							choice = RareTiles;
						}
					}
					var ranPos = Random.Range(0,choice.Length);
					var RanTile = choice[ranPos];
					maze [x,y] = (GameObject)Instantiate(RanTile,new Vector3 (x*tileSize,0,y*tileSize),transform.rotation);
				}
			}
		}
	}

}