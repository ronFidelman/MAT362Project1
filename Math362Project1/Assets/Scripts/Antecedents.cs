using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyAssignment
{
    public class Antecedents
    {

        public enum HorizontalPosition : int
        {
            FarLeft,
            Left,
            Center,
            Right,
            FarRight,
        }

        public enum VerticalPosition : int
        {
            ExtremeBottom,
            Bottom,
            Middle,
            Top,
            ExtremeTop,
        }

        public enum TotalDistance : int
        {
            VeryClose,
            Close,
            SlightlyClose,
            Median,
            SlightlyFar,
            Far,
            VeryFar,
        }


    }
}
