using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour {

  GameObject player = null;
  public float MoveSpeed = 10;

  Rigidbody rb;

  void Start ()
  {
    rb = GetComponent<Rigidbody>();
    var cc = FindObjectOfType<CharacterController>();
    if (cc)
      player = cc.gameObject;
	}
	
	void Update ()
  {
    if (player == null) return;

    Vector3 dirToPlayer = player.transform.position - gameObject.transform.position;
    Vector3 moveVector = dirToPlayer.normalized * MoveSpeed;

    rb.AddForce(moveVector);
  }
}
