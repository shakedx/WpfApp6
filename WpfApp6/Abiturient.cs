using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public class Abiturient
    {
        private int n;
        private Abit_Properties[] cand;
        private string[] strCand;
        private Abit_Properties pattern;
        private Random random;

        public Abiturient()
        {
            n = 15;
            cand = new Abit_Properties[n];
            strCand = new string[n];
            random = new Random();
        }

        public Abiturient(int n)
        {
            this.n = n;
            cand = new Abit_Properties[n];
            strCand = new string[n];
            random = new Random();
        }

        public Abiturient(Abit_Properties[] pp)
        {
            n = pp.Length;
            cand = new Abit_Properties[n];
            strCand = new string[n];
            random = new Random();
        }
        public Abit_Properties Pattern
        {
            set { pattern = value; }
        }

        public void FormCanda()
        {
            int properties = 5;
            int p = 0, q = 0, currentProps = 0;
            string strQ;
            for (int i = 0; i < n; i++)
            {
                currentProps = 0; strQ = "";
                for (int j = 0; j < properties; j++)
                {
                    p = random.Next(2);
                    q = (int)Math.Pow(2, j);
                    if (p == 1)
                    {
                        currentProps += q;
                        strQ += (Abit_Properties)q + ", ";
                    }
                }
                cand[i] = (Abit_Properties)currentProps;
                if (strQ != "") strCand[i] = strQ.Remove(strQ.Length - 2);
                else strCand[i] = "";
            }
        }
        public string[] GetStrCands()
        {
            return strCand;
        }
        public Abit_Properties[] GetCands()
        {
            return cand;
        }
        //список кандидатов, которые обладают свойствами заданными
        //свойствами
        public string[] CandsHavePet()
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if ((cand[i] & pattern) == pattern)
                {
                    k++;
                }
            }
            string[] str = new string[k];
            k = 0;
            for (int i = 0; i < n; i++)
            {
                if ((cand[i] & pattern) == pattern)
                {
                    str[k] = "cand[" + (i + 1) + "]";
                    k++;
                }
            }
            return str;
        }
    }
}