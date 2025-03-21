using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA1
{
   class TestaAluno
    {
        private string nome = "";
        private double nota1 = 0;
        private double nota2 = 0;


        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return this.nome;
        }
        public void setNota1(double nota1)
        {
            this.nota1 = nota1;
        }

        public double getNota1()
        {
            return this.nota1;
        }
        public void setNota2(double nota2)
        {
            this.nota2 = nota2;
        }

        public double getNota2()
        {
            return this.nota2;
        }

        public double getNotaFinal()
        {
            return (this.nota1 + this.nota2) / 2;
        }
        public string getResultado()
        {
            double notaFinal = getNotaFinal();

            if (notaFinal >= 60)
            {
                return "Aprovado =)";
            }
            else if (notaFinal >= 40 && notaFinal <= 59)
            {
                return "Recuperação '-'";
            }
            else
            {
                return "Reprovado =(";
            }

        }
    }
}
