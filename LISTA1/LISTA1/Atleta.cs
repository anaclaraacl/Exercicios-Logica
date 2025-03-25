using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA1
{
    class Atleta
    {
        private string nome;
        private double altura;
        private double peso;
        double imc = 0;

        public Atleta(string nome, double altura, double peso)
        {
            this.nome = nome;
            this.altura = altura;
            this.peso = peso;
        }
        public string GetNome()
        {
            return this.nome;
        }
        public double GetIMC()
        {
            imc = peso / (altura * altura);
            return imc;
        }
        public string GetMensagem()
        {
            if (imc < 18.6)
            {
                return $"{nome} - Abaixo do peso";
            }
            else if (imc > 18.6 && imc < 24.9)
            {
                return $"{nome} - Peso normal";
            }
            else
            {
                return $"{nome} - Acima do peso";
            }
        }
    }
}
