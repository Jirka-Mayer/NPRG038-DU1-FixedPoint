using System;

namespace Cuni.Arithmetics.FixedPoint
{
    public struct Fixed<Q> where Q : IQ, new()
    {
        /// <summary>
        /// How many bits (LSb) contribute to decimal places
        /// </summary>
        private static readonly int DecimalPlaces = new Q().DecimalPlaces();

        /// <summary>
        /// Inner representation of the value, treated as individual bits (32 bits)
        /// </summary>
        private int representation;

        public int Representation => representation;

        public Fixed(int value)
        {
            representation = value << DecimalPlaces;
        }

        public override string ToString()
        {
            double d = (double)representation;
            
            int places = DecimalPlaces;
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
                representation = (int)(
                    ((long)this.representation << DecimalPlaces) / (long)that.representation
                )
            };
        }

        public Fixed<Q> Multiply(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = (int)(
                    ((long)this.representation * (long)that.representation) >> DecimalPlaces
                )
            };
        }
    }
}
