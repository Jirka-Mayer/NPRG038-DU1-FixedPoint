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

        public static implicit operator Fixed<Q>(int i) => new Fixed<Q>(i);

        public static Fixed<Q> From<U>(Fixed<U> from) where U : IQ, new()
        {
            int shiftLeft = new U().DecimalPlaces() - DecimalPlaces;

            if (shiftLeft > 0)
                return new Fixed<Q>() {
                    representation = from.Representation >> shiftLeft
                };
            else
                return new Fixed<Q>() {
                    representation = from.Representation << -shiftLeft
                };
        }

        public static explicit operator Fixed<Q>(Fixed<Q24_8> from) => From<Q24_8>(from);
        public static explicit operator Fixed<Q>(Fixed<Q16_16> from) => From<Q16_16>(from);
        public static explicit operator Fixed<Q>(Fixed<Q8_24> from) => From<Q8_24>(from);

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

        public static Fixed<Q> operator +(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Add(b);
        }

        public Fixed<Q> Subtract(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = this.representation - that.representation
            };
        }

        public static Fixed<Q> operator -(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Subtract(b);
        }

        public static Fixed<Q> operator -(Fixed<Q> a)
        {
            return new Fixed<Q> {
                representation = -a.representation
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

        public static Fixed<Q> operator /(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Divide(b);
        }

        public Fixed<Q> Multiply(Fixed<Q> that)
        {
            return new Fixed<Q> {
                representation = (int)(
                    ((long)this.representation * (long)that.representation) >> DecimalPlaces
                )
            };
        }

        public static Fixed<Q> operator *(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Multiply(b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            return ((Fixed<Q>)obj).Representation == this.Representation;
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Representation == b.Representation;
        }

        public static bool operator !=(Fixed<Q> a, Fixed<Q> b)
        {
            return a.Representation != b.Representation;
        }
    }
}
