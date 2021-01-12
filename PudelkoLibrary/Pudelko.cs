using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace PudelkoLibrary
{
    public sealed class Pudelko : IFormattable, IEquatable <Pudelko>
    {
 
        private double a;
        private double b;
        private double c;
        public double A
        {
            get
            {
                return Math.Round(a, 3);
            }
        }
        public double B
        {
            get
            {
                return Math.Round(b, 3);
            }
        }

        public double C
        {
            get
            {
                return Math.Round(c, 3);
            }
        }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {

            switch (unit)
            {
                case UnitOfMeasure.meter:
                    if (a is null) a = 0.1;
                    if (b is null) b = 0.1;
                    if (c is null) c = 0.1;
                    break;
                case UnitOfMeasure.centimeter:
                    if (a is null) a = 10;
                    if (b is null) b = 10;
                    if (c is null) c = 10;
                    a = a / 100;
                    b = b / 100;
                    c = c / 100;
                    unit = UnitOfMeasure.meter;
                    break;
                case UnitOfMeasure.milimeter:
                    if (a is null) a = 100;
                    if (b is null) b = 100;
                    if (c is null) c = 100;
                    a = a / 1000;
                    b = b / 1000;
                    c = c / 1000;
                    unit = UnitOfMeasure.meter;
                    break;
                default:
                    break;
            }


            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException("Wymiary pudełka muszą być dodatnie.");
            if (a > 10 || b > 10 || c > 10)
                throw new ArgumentOutOfRangeException("Wymiary pudełka nie mogą przekroczyć 10 m.");
            this.a = (double)a;
            this.b = (double)b;
            this.c = (double)c;
        }
        public Pudelko() : this(0.1, 0.1, 0.1)
        {

        }
        public override string ToString()
        {
            return $"{A.ToString("F3")} m \u00D7 {B.ToString("F3")} m \u00D7 {C.ToString("F3")} m";
        }
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format is null)
                format = "m";
            switch (format)
            {
                case "m":
                    return ToString();
                case "cm":
                    return $"{(A * 100).ToString("F1")} cm \u00D7 {(B * 100).ToString("F1")} cm \u00D7 {(C * 100).ToString("F1")} cm";
                case "mm":
                    return $"{A * 1000} mm \u00D7 {B * 1000} mm \u00D7 {C * 1000} mm";
                default:
                    throw new FormatException("Niepoprawny format!");
            }
        }

        public string Objetosc => $"{Math.Round(a * b * c, 1)} m3";
        public string Pole => $"{Math.Round(2 * a * b + 2 * a * c + 2 * b * c,2)} m2";

        public override int GetHashCode()
        {
            return a.GetHashCode() + b.GetHashCode() + c.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals((Pudelko) obj);
        }

        public bool Equals(Pudelko other)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(Pudelko p1, Pudelko p2) => p1.Equals(p2);
        public static bool operator !=(Pudelko p1, Pudelko p2) => !(p1 == p2);

        public static explicit operator double[](Pudelko p) => new double[] { p.A, p.B, p.C };

        public static implicit operator Pudelko(ValueTuple<int, int, int>v) => new Pudelko(v.Item1,v.Item2,v.Item3,UnitOfMeasure.milimeter);

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double[] p11 = (double[])p1;
            double[] p22 = (double[])p2;
            Array.Sort(p11);
            Array.Sort(p22);
            return new Pudelko(
                p11[0] + p22[0], p11[1] + p22[1], p11[2] + p22[2]);
        }
    }
}
