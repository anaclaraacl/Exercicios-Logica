using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTA1
{
    class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano)
        {
            setDia(dia);
            setMes(mes);
            setAno(ano);
        }
        

        public void setDia(int dia)
        {
            if (dia < 1 || dia > 31)
            {
                Console.WriteLine($"Dia inválido: {dia}. O dia deve estar entre 1 e 31.");
            }
            else
            {
                this.dia = dia;
            }
        }

        public int getDia()
        {
            return this.dia;
        }

        public void setMes(int mes)
        {
            if(mes < 1 || mes > 12)
            {
                Console.WriteLine($"Mês inválido: {mes}. O mês deve estar entre 1 e 12.");
            } else
            {
                this.mes = mes;
            }
        }

        public int getMes()
        {
            return this.mes;
        }

        public void setAno(int ano)
        {
            if (ano < 1899 || ano > 2100)
            {
                Console.WriteLine($"Ano inválido: {ano}. O ano deve estar entre 1899 e 2100.");
            }
            else { 
                this.ano = ano;
            }
        }

        public int getAno()
        {
            return this.ano;
        }

        public string retornarData()
        {
            return $"{this.dia:D2}/{this.mes:D2}/{this.ano:D4}";
        }

    }
}
