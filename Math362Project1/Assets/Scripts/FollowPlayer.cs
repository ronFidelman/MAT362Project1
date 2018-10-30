using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FuzzyAssignment;

[RequireComponent(typeof(Rigidbody))]
public class FollowPlayer : MonoBehaviour {

  GameObject player = null;
  public float MoveSpeed = 10;

  Rigidbody rb;

  private FuzzyInference fi = new FuzzyInference();
  private FuzzyInference fif = new FuzzyInference();

  private FollowPlayer[] followers;

  void Start ()
  {
    rb = GetComponent<Rigidbody>();
    var cc = FindObjectOfType<CharacterController>();
    if (cc)
      player = cc.gameObject;

    fi.AddDistanceConsequence(Antecedents.TotalDistance.VeryClose, 0);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.Close, 1);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.SlightlyClose, 3);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.Median,5);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.SlightlyFar,8);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.Far,20);
    fi.AddDistanceConsequence(Antecedents.TotalDistance.VeryFar,15);

    fi.AddDistanceFiringRule(Antecedents.TotalDistance.VeryClose, FiringRules.RuleBasic);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.Close, FiringRules.RuleClose);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.SlightlyClose, FiringRules.RuleBasic);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.Median, FiringRules.RuleMedian);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.SlightlyFar,FiringRules.RuleBasic);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.Far,FiringRules.RuleFar);
    fi.AddDistanceFiringRule(Antecedents.TotalDistance.VeryFar, FiringRules.RuleBasic);


    fif.AddDistanceConsequence(Antecedents.TotalDistance.VeryClose, 0);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.Close, 2);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.SlightlyClose, 0);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.Median, 1f);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.SlightlyFar, 0);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.Far, 0.5f);
    fif.AddDistanceConsequence(Antecedents.TotalDistance.VeryFar, 0);

    fif.AddDistanceFiringRule(Antecedents.TotalDistance.VeryClose, FiringRules.RuleBasic);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.Close, FiringRules.RuleFar);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.SlightlyClose, FiringRules.RuleBasic);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.Median, FiringRules.RuleMedian);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.SlightlyFar, FiringRules.RuleBasic);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.Far, FiringRules.RuleClose);
    fif.AddDistanceFiringRule(Antecedents.TotalDistance.VeryFar, FiringRules.RuleBasic);


    followers = FindObjectsOfType<FollowPlayer>();
  }

  void Update ()
  {
    if (player == null) return;

    Vector3 dirToPlayer = player.transform.position - gameObject.transform.position;
    float length = dirToPlayer.magnitude;
    dirToPlayer.Normalize();
    dirToPlayer *= fi.CalculateDistanceOutput(length);

    Vector3 force = new Vector3(Random.Range(-1,1) * 2, Random.Range(-1, 1) * 2, Random.Range(-1, 1) * 2);
    force += dirToPlayer;

    for (int i = 0; i < followers.Length; i++)
    {
      var pos = followers[i].transform.position;
      if (pos == transform.position)
        continue;
      var dir = transform.position - pos;
      length = dir.magnitude;
      dir.Normalize();
      dir *= fif.CalculateDistanceOutput(length);
      force += dir;
    }
    //force /= 1 + followers.Length;

    rb.AddForce(force);
  }
}
