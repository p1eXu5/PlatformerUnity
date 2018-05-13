using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    #region private

    private Animator _animator;
    private PlayerController _player;
    private bool _pressed;

    #endregion

    public Rigidbody2D bullet;
    public int speed;

    // Use this for initialization
    void Start ()
    {
        _animator = GetComponent<Animator>();
        _player = transform.root.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButton("Fire1") && !_pressed) {

	        _pressed = true;
	        _animator.SetTrigger("Fire");

	        Rigidbody2D bulletInstance;

            if (_player.direction) {
                bulletInstance = Instantiate(this.bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                bulletInstance.velocity = new Vector2(speed, 0);
	        }
	        else {
                bulletInstance = Instantiate(this.bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                bulletInstance.velocity = new Vector2(-speed, 0);
            }

	    }
        else if (Input.GetButtonUp("Fire1")) {

	        _pressed = false;
	    }
	}
}
