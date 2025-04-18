﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
	enum Buttons
	{
		Button,
	}

	//enum Texts
	//{
	//	PointText,
	//	ScoreText,
	//}

	//enum GameObjects
	//{
	//	TestObject,
	//}

	//enum Images
	//{
	//	ItemIcon,
	//}

	public override void Init()
	{
		base.Init();

		Bind<Button>(typeof(Buttons));
		//Bind<Text>(typeof(Texts));
		//Bind<GameObject>(typeof(GameObjects));
		//Bind<Image>(typeof(Images));

		// Extension method를 이용한 방법
		//Get<Button>((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
		Get<Button>((int)Buttons.Button).gameObject.BindEvent(OnButtonClicked);
		//GameObject go = GetImage((int)Images.ItemIcon).gameObject;
		//BindEvent(go, (PointerEventData data) => { go.gameObject.transform.position = data.position; }, Define.UIEvent.Drag);
	}

	//int _score = 0;

	public void OnButtonClicked(PointerEventData data)
	{
		Debug.Log("클릭");
		//++_score;
		//
		//Get<Text>((int)Texts.ScoreText).text = $"점수 : {_score}";
	}
}
