using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyAssignment
{

  public class FiringRules
  {

    public delegate float Rule(float x0);
    public static float RuleBasic(float x0)
    {
      return 0;
    }

    public static float RuleClose(float x0)
    {
      return Mathf.Clamp01((-x0/5.0f + 1));
    }
    public static float RuleMedian(float x0)
    {
      if (x0 > 0 && x0 < 5)
      {
        return x0/5;
      }
      if (x0 >= 5 && x0 <= 10)
      {
        return 2 - x0/5.0f;
      }
      return 0;
    }
    public static float RuleFar(float x0)
    {
      if (x0 > 5)
      {
        return Mathf.Min(x0/5.0f - 1, 1);
      }
      return 0;
    }

  }
}
