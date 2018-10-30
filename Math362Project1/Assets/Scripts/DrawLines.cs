using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLines : MonoBehaviour {

  private LineRenderer line;
  private FollowPlayer[] followers;

	// Use this for initialization
	void Start () {
    line = GetComponent<LineRenderer>();
    line.startWidth = 0.1f;
    line.endWidth = 0.1f;
    line.startColor = Color.black;
    line.endColor = Color.black;

    followers = FindObjectsOfType<FollowPlayer>();
    line.positionCount = followers.Length * 2;
  }
	
	// Update is called once per frame
	void Update () {
    for (int i = 0; i < followers.Length*2; i+=2)
    {
      line.SetPosition(i, transform.position);
      line.SetPosition(i + 1, followers[i / 2].transform.position);
    }
	}
}
