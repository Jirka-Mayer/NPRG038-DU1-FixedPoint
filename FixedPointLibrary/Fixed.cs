using System;
namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<Q> where Q : IQ, new()
    {
        /// <summary>
        /// Inner representation of the value, treated as individual bits (32 bits)
        /// </summary>
        private int representation;

        public Fixed(int value)
        {
            representation = value << new Q().DecimalPlaces();
        }

        public override string ToString()
        {
            return (representation >> new Q().DecimalPlaces()).ToString();
        }
    }
}
