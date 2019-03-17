using System;
namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<Q> where Q : IQ, new()
    {
        /// <summary>
        /// Inner representation of the value, treated as individual bits (32 bits)
        /// </summary>
        private int representation;

        public int Representation => representation;

        public Fixed(int value)
        {
            representation = value << new Q().DecimalPlaces();
        }

        public override string ToString()
        {
            double d = (double)representation;
            
            int places = new Q().DecimalPlaces();
            for (int i = 0; i < places; i++)
                d /= 2;

            return d.ToString();
        }

        public Fixed<Q> Add(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = this.representation + that.representation
            };
        }

        public Fixed<Q> Subtract(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = this.representation - that.representation
            };
        }

        public Fixed<Q> Divide(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = (this.representation << new Q().DecimalPlaces()) / that.representation
            };
        }

        public Fixed<Q> Multiply(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = (this.representation * that.representation) >> new Q().DecimalPlaces()
            };
        }
    }
}
