using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouvementBalle : MonoBehaviour {

	public  GameObject text;
	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;
	public float speed = 100.1f;


	/*
	void OnMouseDown() {
		TextMesh t= text.GetComponent<TextMesh>();
		t.text = "collision";
		this.GetComponent<Rigidbody> ().velocity = new Vector3(0, 10, 5);
	}
*/ void OnMouseDown() 
	{
		mMouseDownPos = Input.mousePosition;
		Debug.Log( "the mouse down pos is " + mMouseDownPos.y.ToString() );
		mMouseDownPos = Input.mousePosition;
		Debug.Log( "the mouse down pos is " + mMouseDownPos.z.ToString() );
		mMouseDownPos.z = mMouseDownPos.y;
	}
	
	void OnMouseUp() 
	{
		mMouseUpPos = Input.mousePosition;
		mMouseUpPos = Input.mousePosition;
		mMouseUpPos.z = mMouseUpPos.y;
		var direction = mMouseDownPos - mMouseUpPos;
		//direction.Normalize();
		this.GetComponent<Rigidbody> ().velocity=  -(direction * speed);
		Debug.Log( "direction " + direction.ToString() );
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
