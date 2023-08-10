using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementType
    {
        RigidbodyVelocity,
        RigidbodyAddForce,
        VectorMoveTowards,
        TransformTranslate,
        DirectPostitionChange
    }

    // The Speed variable can be used in each of the 5 Movement Variants
    [SerializeField] private float speed = 3f;

    // The rigidbody is only used in two of the five Variants
    // If the rigidbody is used, the Physics System is also being used! 
    private Rigidbody2D body;

    // The 2D Vector saves your Movement in both X and Y direction is an "easier" way
    // than checking for each of the buttons pressed. This should also work with gamepads without changes! 
    private Vector2 axisMovement;

    // We can change this variable to change the Movement Type we wish to use
    // This should be changed in the inspector
    [SerializeField] private MovementType movementType = MovementType.RigidbodyVelocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");

        if (movementType == MovementType.VectorMoveTowards)
        {
            MoveTowards();
        }

        if (movementType == MovementType.TransformTranslate)
        {
            Translate();
        }

        if (movementType == MovementType.DirectPostitionChange)
        {
            PositionChange();
        }
    }

    // The Rigidbody Movement Methods are inside the FixedUpdate
    // because they are Physics based which ought to go into this method
    private void FixedUpdate()
    {
        if (movementType == MovementType.RigidbodyVelocity)
        {
            RigidbodyVelocity();
        }

        if (movementType == MovementType.RigidbodyAddForce)
        {
            RigidbodyAddForce();
        }
    }


    #region Movement 1: Rigidbody Velocity

    private void RigidbodyVelocity()
    {
        body.velocity = axisMovement.normalized * speed;
    }

    #endregion


    #region Movement 2: Rigidbody Force

    private void RigidbodyAddForce()
    {
        body.AddForce(axisMovement * speed, ForceMode2D.Impulse);
    }

    #endregion


    #region Movement 3: Vector Move Towards

    private void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            transform.position + (Vector3)axisMovement, speed * Time.deltaTime);
    }

    #endregion


    #region Movement 4: Transform Translate

    private void Translate()
    {
        transform.Translate(axisMovement * speed * Time.deltaTime);
    }

    #endregion


    #region Movement 5: Direct Position Change

    private void PositionChange()
    {
        transform.position += (Vector3)axisMovement * Time.deltaTime * speed;
    }

    #endregion
}