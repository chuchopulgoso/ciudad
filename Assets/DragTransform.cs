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
		var rotationVector = transform.rotation.eulerAngles;
		rotationVector.x = 0;
		rotationVector.y = 0;
		rotationVector.z = 0;

		var positionVector = transform.position;
		positionVector.x = 0;
		positionVector.y = 0;
		positionVector.z = 0;

		if (collision.gameObject.name == "Terrain")
		{ 
			if(gameObject.name == "Street1Lane30m")
			{
				rotationVector.x = 270;
			}
			transform.rotation = Quaternion.Euler(rotationVector); 
		} 
		if (collision.gameObject.name == "Block_Building_Low")
		{ 
			renderer.material.color = Color.red;
			dragging = false;
		} 
		if (collision.gameObject.name == "Street1Lane30m")
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
			if (rayPoint.y < 0)
			{
				rayPoint.y = 0;
			}
			transform.position = rayPoint;
		}
	}
}
