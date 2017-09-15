using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private Camera _camera;
	private Grid _grid;
	
	

	private void Start()
	{
		_camera = GetComponent<Camera>();
	
		_grid = GameObject.FindGameObjectWithTag ("GridSpawner").GetComponent<Grid> ();
	}

	// Update is called once per frame
	private void Update()
	{

		var ray = _camera.ScreenPointToRay(Input.mousePosition);
		if (!Input.GetMouseButtonDown(0)) return;
		RaycastHit hit;
		if (!Physics.Raycast(ray, out hit)) return;
		print("I'm looking at " + hit.transform.name);
		if (hit.collider.CompareTag ("Bomb"))
		{
			StartCoroutine(Restarter());

		}
		if (hit.collider.CompareTag ("NotABomb"))
		{
			print("nee");
		   //SetActive(false);
			// voer hier flood fill function uit
		}
	}

	private static IEnumerator Restarter()
	{
		
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("Main");


	}
}
