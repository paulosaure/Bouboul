using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouvementBalle : MonoBehaviour {

	public  GameObject text ,t2;
	Vector3 mMouseDownPos;
	Vector3 mMouseUpPos;
    private Vector3 vitesse;
    public Camera cam;
    private Vector2 posInit,posEnd;
    private float temp;
    private float coefSpeed = 300;
    private float coefDelta = 7;
    /*
 void OnMouseDown() 
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
    */
	
	// Update is called once per frame
	void Update () {
        int nbTouches = Input.touchCount;
        if (nbTouches > 0)
        {
            //text.GetComponent<TextMesh>().text = " nbTouche";

            for (int i = 0; i < nbTouches; i++)
            {

                Touch touch = Input.GetTouch(i);
                TouchPhase phase = touch.phase;
                Vector2 v2 = Vector2.zero;
                v2 = Input.GetTouch(i).position;
                Vector3 wp = Vector3.zero;
                wp = cam.ScreenToWorldPoint(v2);

                switch (phase)
                {
                    case TouchPhase.Began :
                        posInit=touch.position;
                        break;
                    case TouchPhase.Ended:
                        posEnd = touch.position;
                        var d = posEnd - posInit;
                        d.x /= Screen.width;
                        d.y /= Screen.height;
                        d.x *= coefDelta;
                        d.y *= coefDelta;
                        text.GetComponent<TextMesh>().text = " mon delta= " + d;
                        vitesse.x = d.x;
                        vitesse.y = d.y;
                        vitesse.z = d.y;
                        vitesse *= temp;
                        this.GetComponent<Rigidbody>().velocity = vitesse;
                        t2.GetComponent<TextMesh>().text = " vitesse = " + vitesse;
                        break;
                    case TouchPhase.Moved:
                        if (touch.deltaPosition != Vector2.zero && touch.deltaTime!=0)
                        {
                            var t = touch.deltaPosition;
                           temp= (t.magnitude/touch.deltaTime)/coefSpeed;
                            //text.GetComponent<TextMesh>().text = " valeur speed = " + temp;

                            


                        }
                        break;
                    default: break;
                }
            }
        }
	}
}
