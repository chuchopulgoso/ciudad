using UnityEngine;
using System.Collections;

public class ResizableObject : MonoBehaviour
{
	public float maxScale = 100.0f;
	public float minScale = 2.0f;
	public float shrinkSpeed = 1.0f;
	
	private float targetScale;
	private Vector3 v3Scale;
	
	void Start() 
	{
		v3Scale = transform.localScale;
	}
	
	void Update()
	{
		RaycastHit hit;
		Ray ray;
		
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = minScale;
				//v3Scale = new Vector3(targetScale, 0.1f, 10);
				v3Scale = new Vector3(v3Scale.x * targetScale, 0.1f, 10);
			}
			
		}
		
		if (Input.GetMouseButtonDown (1)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = maxScale;
				//v3Scale = new Vector3(targetScale, 0.1f, 10);
				v3Scale = new Vector3(v3Scale.x * targetScale, 0.1f, 10);
			}
		}
		
		transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime*shrinkSpeed);
	}
}