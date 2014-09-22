using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Partida
{
	public int dinero;
	public int poblacion;
	public List<Edificio> edificios = new List<Edificio>();	
}

[Serializable]
public class Edificio
{
	public string nombre;
	public float posX = 0.0f;
	public float posY = 0.0f;
}

public class GuardarCargar : MonoBehaviour {

	public Partida partida = new Partida();
	public List	<GameObject> objetosEdificio = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Debug.Log("hola");
		objetosEdificio.Add(GameObject.FindGameObjectWithTag ("Edificio1"));
		objetosEdificio.Add(GameObject.FindGameObjectWithTag ("Edificio2"));
		if (File.Exists("partida"))
		{	
			Debug.Log ("Lo encuentro y lo cargo");
			partida = Deserialize<Partida>("partida");
			objetosEdificio[0].transform.position= new Vector3(partida.edificios[0].posX, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("s")) 
		{
			Edificio datosEdificio = new Edificio();
			Debug.Log (partida);
			Debug.Log (partida.edificios.Count);
			foreach (var edificio in objetosEdificio) 
			{Debug.Log(edificio);
				datosEdificio.posX = edificio.transform.position.x;
				datosEdificio.posY = edificio.transform.position.y;
				
				
				partida.edificios.Add(datosEdificio);
				Debug.Log(datosEdificio.posX);
			}
			Serialize(partida,"partida");
		}
	}
	
	/// <summary>
	/// Serializa un objeto a un archivo binario.
	/// </summary>
	/// <param name="data">Objeto a serializar.</param>
	/// <param name="filename">Archivo binario a generar.</param>
	public static void Serialize(object data, string filename)
	{
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, data);
		stream.Close();
	}
	
	/// <summary>
	/// Deserializa un archivo binario a objeto.
	/// </summary>
	/// <typeparam name="T">Tipo del objeto a deserializar.</typeparam>
	/// <param name="filename">Archivo binario a deserializar.</param>
	/// <returns>Devuelve la instancia de la clase serializada.</returns>
	public static T Deserialize<T>(string filename)
	{
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
		T ret = (T)formatter.Deserialize(stream);
		stream.Close();
		return ret;
	}
	
	
}
