using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
    private float movePos = .5f;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 position = this.transform.position;
            position.x -= movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 position = this.transform.position;
            position.x += movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 position = this.transform.position;
            position.y += movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2 position = this.transform.position;
            position.y -= movePos;
            this.transform.position = position;
        }
    }
}
