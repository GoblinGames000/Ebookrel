/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject brush;

	private Color currentColor;
	public SpriteRenderer coloredPart;
	public Color coloredPartColor;
	private AudioSource audioSource;

	private Vector3 Postion = Vector3.zero;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		currentColor = brush.transform.GetChild(0).GetComponent<SpriteRenderer>().color;

	}

	private void Update()
	{
		Postion = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
		Postion.z = -5f;
		if (Input.GetMouseButtonDown(0))
		{
			RayCast2D();
		}
		if (brush != null)
		{
			brush.transform.position = Postion;
		}
	}

	private void RayCast2D()
	{
		RaycastHit2D raycastHit2D = Physics2D.Raycast(Postion, Vector2.zero);
		if (!(raycastHit2D.collider == null))
		{
			if (raycastHit2D.collider.tag == "BrushColor")
			{
				currentColor = raycastHit2D.collider.GetComponent<Image>().color;
				brush.transform.GetChild(0).GetComponent<SpriteRenderer>().color = currentColor;
			}
			else if (raycastHit2D.collider.tag == "ImagePart")
			{
				raycastHit2D.collider.GetComponent<SpriteRenderer>().color = currentColor;
				coloredPart=raycastHit2D.collider.GetComponent<SpriteRenderer>();
				coloredPartColor = currentColor;
			}
		}
	}

	public void Undo()
	{
		
		Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
		if(coloredPart==null) return;
		coloredPart.color=Color.white;
	}
	public void Redo()
	{
		Sound_Manager.instance.PlayOnshootSound(Sound_Manager.instance.buttonClick);
		if(coloredPart==null) return;

		coloredPart.color = coloredPartColor;
	}
}
