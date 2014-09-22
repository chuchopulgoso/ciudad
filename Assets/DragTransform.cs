using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Color mouseOverColor = Color.blue;
	private Color originalColor = Color.yellow;
	private bool dragging = false;
	private float distance;
	Vector3 originalPosition;
	Vector3 rayPoint;
	Ray ray;
	Ray rayOriginal;


	void OnMouseEnter()
	{
		renderer.material.color = mouseOverColor;
	}
	
	void OnMouseExit()
	{
		renderer.material.color = originalColor;
	}
	
	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
	
	void OnMouseUp()
	{
		dragging = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		if ((collision.gameObject.name == "Edificio1(Clone)") || collision.gameObject.name == "ViaHorizontal(Clone)")
		{ 
			renderer.material.color = Color.red;
			dragging = false;
		} 
	}

	
	void Update()
	{
		if (dragging)
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			rayOriginal = ray;
			rayPoint = ray.GetPoint(distance);
			rayPoint.y = 0;
			transform.position = rayPoint;
		}
	}
}
