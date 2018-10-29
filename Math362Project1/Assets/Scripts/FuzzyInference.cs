using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Antecedents;

namespace FuzzyAssignment
{
    public class FuzzyInference {
        private Dictionary<Antecedents.HorizontalPosition, float> mHorizontalSpeedAdjust;
        private Dictionary<Antecedents.VerticalPosition, float> mVerticalSpeedAdjust;
        private Dictionary<Antecedents.TotalDistance, float> mDistanceAdjust;

        public FuzzyInference()
        {
            mHorizontalSpeedAdjust = new Dictionary<Antecedents.HorizontalPosition, float>();
            mVerticalSpeedAdjust = new Dictionary<Antecedents.VerticalPosition, float>();
            mDistanceAdjust = new Dictionary<Antecedents.TotalDistance, float>();
        }

        public void AddHorizontalConsequence(Antecedents.HorizontalPosition aPos, float aConsequence)
        {
            mHorizontalSpeedAdjust.Add(aPos, aConsequence);
        }

        public void AddVerticalConsequence(Antecedents.VerticalPosition aPos, float aConsequence)
        {
            mVerticalSpeedAdjust.Add(aPos, aConsequence);
        }

        public void AddDistanceConsequence(Antecedents.TotalDistance aPos, float aConsequence)
        {
            mDistanceAdjust.Add(aPos, aConsequence);
        }
    }
}
