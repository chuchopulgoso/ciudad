using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour
{
	public Transform edificio; 
	public Transform via;
	Vector3 rayPoint;
	bool esEdificio = false;
	bool esVia = false;
	//	public int toolbarInt = 0;
	//	public string[] toolbarStrings = new string[] {"Edificio1", "Edificio2", "Carretera3"};
	Plane plane;
	
	void OnGUI() 
	{
		if (GUI.Button(new Rect(5,5,75,25),"Edificio"))
		{
			esEdificio = true;
		}

		if (GUI.Button(new Rect(80,5,125,25),"Via Horizontal"))
		{
			esVia = true;
		}
	}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(esEdificio || esVia)
			{
			Vector3 mousePos=new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
				
				if(Input.GetMouseButtonDown(0)) 
				{
					Vector3 wordPos;
					Ray ray=Camera.main.ScreenPointToRay(mousePos);
					RaycastHit hit;
					if(Physics.Raycast(ray,out hit,1000f)) 
					{
						wordPos=hit.point;
					} 
					else 
					{
						wordPos=Camera.main.ScreenToWorldPoint(mousePos);
					}
					wordPos.y=0;
					if(esEdificio)
					{
						Instantiate(edificio,wordPos,Quaternion.identity);
						esEdificio = false;
					}
					if(esVia)
					{
						Instantiate(via,wordPos,Quaternion.identity);
						esVia = false;
					}
				}
			}
		}
}

