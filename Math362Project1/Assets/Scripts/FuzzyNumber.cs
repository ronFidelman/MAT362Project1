using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyAssignment
{

    public class FuzzyNumber
    {

        private double mValue;

        public FuzzyNumber(double value)
        {
            mValue = value;
        }

        public bool IsTrue()
        {
            return mValue > .5;
        }

        public static FuzzyNumber operator |(FuzzyNumber numA, FuzzyNumber numB)
        {
            return new FuzzyNumber(Math.Max(numA.mValue, numB.mValue));
        }

        public static FuzzyNumber operator &(FuzzyNumber numA, FuzzyNumber numB)
        {
            return new FuzzyNumber(Math.Min(numA.mValue, numB.mValue));
        }

        public static FuzzyNumber operator !(FuzzyNumber numA)
        {
            return new FuzzyNumber(1.0 - numA.mValue);
        }
    }
}
