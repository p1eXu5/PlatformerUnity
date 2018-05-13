using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region private

    private Rigidbody2D _rigitBody;
    private Animator _animator;
    private bool _jump = false;
    private int _jumpForce;
    private int _if = 0; 
    private int _iu = 0; 

    #endregion

    [HideInInspector]
    public bool direction;

    public int maxSpeed;
    public int moveForce;
    public int maxJumpSpeed;
    public int jumpForce;

    // Use this for initialization
    void Start ()
    {
        _rigitBody = GetComponent<Rigidbody2D> ();
        _animator = GetComponent<Animator> ();

        direction = true;
        Flip();

        _jumpForce = jumpForce;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    print(_rigitBody.velocity.y);
        if (Input.GetButtonDown ("Jump") && _rigitBody.velocity.y == 0) {
            _jump = true;
        }

        if (Input.GetButtonUp ("Jump")) {

            _jump = false;
            _jumpForce = jumpForce;
        }
	}

    void FixedUpdate ()
    {

        var h = Input.GetAxis ("Horizontal");
        var v = Input.GetAxis ("Vertical");
        var currentSpeed = _rigitBody.velocity.x;

        _animator.SetFloat("Speed", Mathf.Abs(h));

        _rigitBody.AddForce(Vector2.right * h * moveForce);

        if (_jump) {



            if (_rigitBody.velocity.y < maxJumpSpeed)
                _rigitBody.AddForce (Vector2.up * _jumpForce);
            else
                _jumpForce = 0;


            if (_rigitBody.velocity.y > maxJumpSpeed)
                _rigitBody.velocity = new Vector2 (_rigitBody.velocity.x, maxJumpSpeed);
        }


        if (h > 0 && !direction) {

            direction = true;
            Flip();
        }
        else if (h < 0 && direction) {

            direction = false;
            Flip();
        }

        //Debug.Log(h);

        if (Mathf.Abs(currentSpeed) < maxSpeed)
            _rigitBody.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(_rigitBody.velocity.x) > maxSpeed)
            _rigitBody.velocity = new Vector2(Mathf.Sign(_rigitBody.velocity.x) * maxSpeed, _rigitBody.velocity.y);
    }

    void Flip()
    {
        var tmpVector = transform.localScale;

        if (!direction) {

            tmpVector.x = -(Mathf.Abs(transform.localScale.x));
        }
        else {

            tmpVector.x = Mathf.Abs(transform.localScale.x);
        }

        transform.localScale = tmpVector;
    }
}
