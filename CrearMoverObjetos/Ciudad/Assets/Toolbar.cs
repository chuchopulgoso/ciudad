using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour
{
	public Transform edificio; 
	public Transform vias;
	Vector3 rayPoint;
	//	public int toolbarInt = 0;
	//	public string[] toolbarStrings = new string[] {"Edificio1", "Edificio2", "Carretera3"};
	
	void OnGUI() {
		//		toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings);
		
		if (GUI.Button(new Rect(5,5,75,25),"Edificio"))
		{
			rayPoint.x = 550;
			rayPoint.z = 800;
			Instantiate(edificio, rayPoint, Quaternion.identity);
		}
		if (GUI.Button(new Rect(80,5,75,25),"Vias"))
		{
			rayPoint.x = 550;
			rayPoint.z = 800;
			Instantiate(vias, rayPoint, Quaternion.Euler(270, 0, 0));
		}
	}

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

