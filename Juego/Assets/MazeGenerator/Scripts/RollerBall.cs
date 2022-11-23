using UnityEngine;
using System.Collections;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour {

	public GameObject ViewCamera = null;
	public AudioClip JumpSound = null;
	public AudioClip HitSound = null;
	public AudioClip CoinSound = null;
	public GameObject Canvas;
	private UIController uiController;

    private float speed = 0.15f;
	private Rigidbody mRigidBody = null;
	private AudioSource mAudioSource = null;
	private bool mFloorTouched = false;

	void Start () {
		uiController = Canvas.GetComponent<UIController>();
		mRigidBody = GetComponent<Rigidbody> ();
		mAudioSource = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		if (mRigidBody != null) {
			// Controlando al jugador
			if (Input.GetButton ("Horizontal")) {
				mRigidBody.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Impulse);
			}
			if (Input.GetButton ("Vertical")) {
                mRigidBody.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed, ForceMode.Impulse);
			}
		}
		if (ViewCamera != null) {
			Vector3 ballPosition = transform.position;
			Vector3 direction = (Vector3.up * 2 + Vector3.back) * 5;

			ViewCamera.transform.position = direction + ballPosition;
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = true;
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		} else {
			if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f) {
				mAudioSource.PlayOneShot (HitSound, coll.relativeVelocity.magnitude);
			}
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			mFloorTouched = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Coin")) {
			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			StartCoroutine(uiController.mostrarPrincipio());
			Destroy(other.gameObject);
		}
	}
}
