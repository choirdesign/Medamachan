﻿using UnityEngine;
using System.Collections;

public class StageController3 : MonoBehaviour {
	public TextAsset _layout;
	//配列として宣言 要素の数はインスペクタ上で設定
	//インスペクタ上でアンダーバーが消えて頭が大文字になってる
	public GameObject[] _objs;

	// Use this for initialization
	void Start () {
		this.readMap();
	}

	void readMap() {

		//改行位置で区切る
		//引数をchar[]型で渡すことで、区切る文字を複数指定している。
		char[] kugiri = {'\r', '\n'};
		string[] layoutInfo = _layout.text.Split(kugiri);

		//
		string[] eachInfo;
		for (int i = 0; i < layoutInfo.Length; i++) {
			//カンマで区切る
			eachInfo = layoutInfo[i].Split(","[0]);
			//現在の行の1文字目[0]で判別
			int objNumber = getObj(eachInfo[0]);
			//#1 インスペクタで設定したオブジェクトの要素に対応したオブジェクトを定義
			GameObject obj = _objs[objNumber];

			//#2 2文字目[1]をx座標、3文字目[2]をy座標に設定(Parse()で文字列を整数値に)する
			Vector2 pos = new Vector2(int.Parse (eachInfo[1]),
				int.Parse(eachInfo[2]));
				
			//#1で設定した種類のオブジェクトを#2で得た座標に生成する
			this.createObj(obj, pos);
		}
	}

	//取り出した文字を数字にして返す
	int getObj(string objType)
	{
		int resultNum = 0;
		switch(objType){
		case "A":
			resultNum = 0;
			break;
		case "B":
			resultNum = 1;
			break;
			//case "C":
			//resultNum = 2;
			//break;
			//case "D":
			//resultNum = 3;
			//break;
		default:
			resultNum = 0;
			break;
		}
		//返す
		return resultNum;
	}

	//GameObjectと位置（z座標除く）を引数として渡し、その位置にGameObjectを生成。
	void createObj(GameObject obj, Vector2 pos)
	{
		GameObject go = Instantiate(obj,
			new Vector3 (pos.x, pos.y, 0),
			obj.transform.rotation) as GameObject;
	}
}
