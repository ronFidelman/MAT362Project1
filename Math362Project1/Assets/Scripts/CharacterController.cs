using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour {

  public KeyCode Up = KeyCode.UpArrow;
  public KeyCode Down = KeyCode.DownArrow;
  public KeyCode Left = KeyCode.LeftArrow;
  public KeyCode Right = KeyCode.RightArrow;

  public float MoveSpeed = 5;
  public float MaxSpeed = 20;

  Rigidbody rb;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update () {
    Vector3 movementForce = new Vector3();

    if(Input.GetKey(Up))
    {
      movementForce.y += 1;
    }
    if (Input.GetKey(Down))
    {
      movementForce.y += -1;
    }

    if (Input.GetKey(Right))
    {
      movementForce.x += 1;
    }
    if (Input.GetKey(Left))
    {
      movementForce.x += -1;
    }
    movementForce = movementForce.normalized * MoveSpeed;

    rb.AddForce(movementForce);

    if(rb.velocity.sqrMagnitude > MaxSpeed*MaxSpeed)
    {
      rb.velocity = rb.velocity.normalized * MaxSpeed;
    }
  }
}
