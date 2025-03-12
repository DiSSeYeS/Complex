using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    public class Complex
    {
        private float Re;
        private float Im;
        public Complex(float a = 0, float b = 0)
        {
            Re = a;
            Im = b;
        }
        public void AddRe(float num) => this.Re += num;
        public void AddIm(float num) => this.Im += num;
        public void SubRe(float num) => this.Re -= num;
        public void SubIm(float num) => this.Im -= num;
        public void Multiply(float num)
        {
            this.Re *= num;
            this.Im *= num;
        }
        public void Divise(float num)
        {
            this.Re /= num;
            this.Im /= num;
        }
        public void Pow(float num)
        {
            float oldRe, oldIm;

            oldRe = this.Re;
            oldIm = this.Im;

            for (int i = 0; i < num - 1; i++)
            {
                this.Re *= oldRe;
                this.Re += -(oldIm * oldIm);

                this.Im = 2 * oldRe * oldIm;
            }
        }
        public static Complex operator +(Complex a) => a;
        public static Complex operator -(Complex a) => new Complex(-a.Re, -a.Im);
        public static Complex operator +(Complex a, Complex b) => new Complex(a.Re + b.Re, a.Im + b.Im);
        public static Complex operator -(Complex a, Complex b) => new Complex(a.Re - b.Re, a.Im - b.Im);
        public static Complex operator +(Complex a, float b) => new Complex(a.Re + b, a.Im);
        public static Complex operator -(Complex a, float b) => new Complex(a.Re - b, a.Im);
        public static Complex operator *(Complex a, float b) => new Complex(a.Re * b, a.Im * b);
        public static Complex operator /(Complex a, float b) => new Complex(a.Re / b, a.Im / b);
        public static Complex operator *(Complex a, Complex b) => new Complex(-(a.Im * b.Im) + a.Re * b.Re, a.Re * b.Im + a.Im * b.Re);
        public static Complex operator *(Complex a, string i)
        {
            bool isNegative = i.Trim().StartsWith("-");
            string delta = "";

            if (!i.Contains('j'))
            {
                throw new Exception("Imaginary part is not found.");
            }

            do { i = i.Trim('-', 'j', ' '); }
            while (i != i.Trim());

            foreach (var digit in i)
            {
                delta += digit;
            }

            delta += delta.Equals("") ? "1" : "";

            return isNegative switch
            {
                true => new Complex(a.Im * int.Parse(delta), -a.Re * int.Parse(delta)),
                _ => new Complex(-a.Im * int.Parse(delta), a.Re * int.Parse(delta)),
            };
        }
        public static Complex operator +(Complex a, string i)
        {
            bool isNegative = i.Trim().StartsWith("-");
            string delta = "";

            if (!i.Contains('j'))
            {
                throw new Exception("Imaginary part is not found.");
            }

            do
            {
                i = i.Trim('-', 'j', ' ');
            }
            while (i != i.Trim());

            foreach (var digit in i)
            {
                delta += digit;
            }

            delta += delta.Equals("") ? "1" : "";

            return isNegative switch
            {
                true => new Complex(a.Re, a.Im - int.Parse(delta)),
                _ => new Complex(a.Re, a.Im + int.Parse(delta)),
            };
        }
        public static Complex operator -(Complex a, string i)
        {
            bool isNegative = i.Trim().StartsWith("-");
            string delta = "";

            if (!i.Contains('j'))
            {
                throw new Exception("Imaginary part is not found.");
            }

            do
            {
                i = i.Trim('-', 'j', ' ');
            }
            while (i != i.Trim());

            foreach (var digit in i)
            {
                delta += digit;
            }

            delta += delta.Equals("") ? "1" : "";

            return isNegative switch
            {
                true => new Complex(a.Re, a.Im + int.Parse(delta)),
                _ => new Complex(a.Re, a.Im - int.Parse(delta)),
            };
        }
        public static Complex operator /(Complex a, string i)
        {
            bool isNegative = i.Trim().StartsWith("-");
            string delta = "";

            if (!i.Contains('j'))
            {
                throw new Exception("Imaginary part is not found.");
            }

            do
            {
                i = i.Trim('-', 'j', ' ');
            }
            while (i != i.Trim());

            foreach (var digit in i)
            {
                delta += digit;
            }

            delta += delta.Equals("") ? "1" : "";

            return isNegative switch
            {
                true => new Complex(-a.Im / int.Parse(delta), a.Re / int.Parse(delta)),
                _ => new Complex(a.Im / int.Parse(delta), -a.Re / int.Parse(delta)),
            };
        }
        public override string ToString()
        {
            string complexNum = "";

            if (Re != 0)
            {
                complexNum += Re;

                if (Im > 0) complexNum += $" + {Im}j";
                else if (Im < 0) complexNum += $" - {-Im}j";
            }
            else
            {
                if (Im > 0) complexNum += $"{Im}j";
                else if (Im < 0) complexNum += $"{Im}j";
            }

            return complexNum;
        }
    }
}
