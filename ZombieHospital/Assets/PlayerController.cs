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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 position = this.transform.position;
            position.x -= movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 position = this.transform.position;
            position.x += movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 position = this.transform.position;
            position.y += movePos;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 position = this.transform.position;
            position.y -= movePos;
            this.transform.position = position;
        }
    }
}
