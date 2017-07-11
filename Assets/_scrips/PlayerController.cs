using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int pickupCount;

	void Start () {
		rb = GetComponent<Rigidbody>();
		pickupCount = 0;
		winText.text = "";
		SetCountText ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("pickup")) {
			other.gameObject.SetActive (false);
			pickupCount = pickupCount + 1;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + pickupCount.ToString ();
		if (pickupCount >= 12) {
			winText.text = "You Win!";
		}
	}
}
