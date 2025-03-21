using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA1
{
    class Aluno
    {
        private int matricula;
        private string nome;
        private double nota1;
        private double nota2;
        private double nota3;

        public Aluno(int mat, string nome, double n1, double n2, double n3)
        {
            this.matricula = mat;
            this.nome = nome;
            this.nota1 = n1;
            this.nota2 = n2;
            this.nota3 = n3;
        }

        public int GetMatricula()
        {
            return this.matricula;
        }
        public string GetNome()
        {
            return this.nome;
        }
        public double GetNotaFinal()
        {
            return (this.nota1 + this.nota2 + this.nota3) / 3;
        }
        public string GetResultado()
        {
            double notaFinal = GetNotaFinal();

            if (notaFinal >= 60)
            {
                return "Aprovado";
            }
            else if (notaFinal >= 40 && notaFinal <= 59)
            {
                return "Recuperação";
            }
            else
            {
                return "Reprovado";
            }

        }
    }
}
