using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyAssignment
{
  public class FuzzyInference
  {
    private Dictionary<Antecedents.TotalDistance, float> mDistanceConsequences;
    private Dictionary<Antecedents.TotalDistance, FiringRules.Rule> mDistanceA;

    public FuzzyInference()
    {
      mDistanceConsequences = new Dictionary<Antecedents.TotalDistance, float>();
      mDistanceA = new Dictionary<Antecedents.TotalDistance, FiringRules.Rule>();
    }

    public void AddDistanceConsequence(Antecedents.TotalDistance aPos, float aConsequence)
    {
      mDistanceConsequences.Add(aPos, aConsequence);
    }
    public void AddDistanceFiringRule(Antecedents.TotalDistance aPos, FiringRules.Rule rule)
    {
      mDistanceA.Add(aPos, rule);
    }


    public float CalculateDistanceOutput(float input)
    {
      float numerator = 0;
      float denominator = 0;
      for (int i = 0; i < Enum.GetNames(typeof(Antecedents.TotalDistance)).Length; i++)
      {
        float alphai = mDistanceA[(Antecedents.TotalDistance)i](input);
        float zi = mDistanceConsequences[(Antecedents.TotalDistance)i];
        numerator +=  alphai * zi;
        denominator += alphai;
      }

      return numerator / denominator;
    }
    
  }
}
