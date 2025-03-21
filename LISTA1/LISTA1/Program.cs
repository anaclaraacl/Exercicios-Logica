using System;
using System.Data;
using System.Net;
using System.Runtime.Intrinsics.X86;
using LISTA1;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Escolha uma atividade:");
        Console.WriteLine("1. Atividade 1");
        Console.WriteLine("2. Atividade 2");
        Console.WriteLine("3. Atividade 3");
        Console.WriteLine("4. Atividade 4");
        Console.WriteLine("5. Atividade 5");
        Console.WriteLine("6. Atividade 6");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Ex1();
                break;
            case 2:
                Ex2();
                break;
            case 3:
                Ex3();
                break;
            case 4:
                Ex4();
                break;
            case 5:
                Ex5();
                break;
            case 6:
                Ex6();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    private static void Ex1()
    {
        /*
        Escreva um programa que preencha um vetor de N elementos inteiros, calcule a soma, a média aritmética, a quantidade de elementos abaixo da média, 
        o índice do maior e o índice do menor. O valor de N deverá ser informado pelo usuário no início da execução.
        */
        Console.WriteLine("Informe o tamanho do vetor: ");
        int N = int.Parse(Console.ReadLine());
        int[] vetor = new int[N];
        int soma = 0;
        double media = 0;
        int maior, menor;
        int contAbaixoDaMedia = 0;

        for (int i = 0; i < N; i++)
        {
            Console.Write($"Digite o elemento {i + 1}: ");
            vetor[i] = int.Parse(Console.ReadLine());
            soma += vetor[i];
        }

        media = soma / N;

        maior = vetor[0];
        menor = vetor[0];

        for (int i = 0; i < N; i++)
        {
            if (vetor[i] > maior)
            {
                maior = vetor[i];
            }
            if (vetor[i] < menor)
            {
                menor = vetor[i];
            }
            if (vetor[i] < media)
            {
                contAbaixoDaMedia++;
            }
        }
        Console.WriteLine($"Soma: {soma}");
        Console.WriteLine($"Média: {media:F2}");
        Console.WriteLine($"Quantidade de elementos abaixo da média: {contAbaixoDaMedia}");
        Console.WriteLine($"Índice do maior: {Array.IndexOf(vetor, maior)}");
        Console.WriteLine($"Índice do menor: {Array.IndexOf(vetor, menor)}");
    }
    private static void Ex2()
    {
        /* Escreva um programa que preencha aleatoriamente uma matriz real de 6x6, calcule a soma e a média dos elementos situados acima da diagonal secundária,
        incluindo a própria diagonal.
        */

        Random random = new Random();
        int[,] matriz = new int[6, 6];
        int soma = 0;
        int contador = 0;
        double media = 0;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                matriz[i, j] = random.Next(1, 11);
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (i + j <= 5) // Condição para os elementos acima da diagonal secundária
                {
                    soma += matriz[i, j];
                    contador++;
                }
            }
        }
        media = soma / contador;
        Console.WriteLine("Soma dos elementos situados acima da diagonal secundária, incluindo a própria diagonal: " + soma);
        Console.WriteLine("Média dos elementos situados acima da diagonal secundária, incluindo a própria diagonal: " + media);
    }
    private static void Ex3()
    {
        /*
        O IBOPE deseja fazer uma pesquisa de audiência das rádios locais. Para tal, cada entrevistado deverá informar: 
        - Idade
        - Sexo (1-Masculino, 2-Feminino)
        - Estado Civil (1-Casado, 2-Solteiro, 3-Viúvo, 4-Divorciado)
        - Rádio Preferia (1-BHfm, 2-98fm, 3-Jovem Pan, 4-Itatiaia, 5-CDL) - Qualquer outro valor deverá ser contabilizado como "Outros".

        A entrevista se encerra quando for digitada idade igual a 0. Calcular e imprimir:
        a) % de audiência de cada rádio (incluindo outros);
        b) nº de mulheres divorciadas que preferem CDL;
        c) nº de homens menores de 18 anos que preferem Jovem Pan;
        d) média das idades;
        e) % de homens e de mulheres.
       */

        int somaIdades = 0;
        int contador = 0;
        int totalMulheresDivorciadas = 0;
        int totalHomensMenores = 0;
        int totalHomens = 0;
        int totalMulheres = 0;


        int[] audienciaRadios = new int[6];

        while (true)
        {
            Console.WriteLine("Digite a sua idade ou 0 sair:");
            int idade = int.Parse(Console.ReadLine());

            if (idade == 0)
                break;

            somaIdades += idade;

            Console.WriteLine("Digite a opção que corresponde ao seu sexo:");
            Console.WriteLine("1. Masculino");
            Console.WriteLine("2. Feminino");
            int opcaoSexo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a opção que corresponde ao seu estado civil:");
            Console.WriteLine("1. Casado");
            Console.WriteLine("2. Solteiro");
            Console.WriteLine("3. Viúvo");
            Console.WriteLine("4. Divorciado");
            int opcaoEstadoCivil = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a opção que corresponde a sua rádio preferida:");
            Console.WriteLine("1. BHfm");
            Console.WriteLine("2. 98fm");
            Console.WriteLine("3. Jovem Pan");
            Console.WriteLine("4. Itatiaia");
            Console.WriteLine("5. CDL");
            Console.WriteLine("6. Outros");
            int opcaoRadio = int.Parse(Console.ReadLine());

            if (opcaoRadio >= 1 && opcaoRadio <= 6)
            {
                audienciaRadios[opcaoRadio - 1]++;
            }

            contador++;

            if (opcaoSexo == 2 && opcaoEstadoCivil == 4 && opcaoRadio == 5) totalMulheresDivorciadas++;

            if (opcaoSexo == 1 && idade < 18 && opcaoRadio == 3) totalHomensMenores++;

            if (opcaoSexo == 1) totalHomens++;
            if (opcaoSexo == 2) totalMulheres++;
        }

        if (contador > 0)
        {
            Console.WriteLine("Resultados da pesquisa: ");
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < audienciaRadios.Length; i++)
            {
                double porcentagem = (double)audienciaRadios[i] / contador * 100;
                Console.WriteLine($"Audiência da rádio {(i + 1)}: {porcentagem:F2}%");
            }

            Console.WriteLine();
            Console.WriteLine("Quantidade de mulheres divorciadas que preferem a rádio CDL: " + totalMulheresDivorciadas);
            Console.WriteLine();
            Console.WriteLine("Quantidade de homens menores de 18 anos que preferem a rádio Jovem Pan: " + totalHomensMenores);
            Console.WriteLine();

            double media = (double)somaIdades / contador;
            Console.WriteLine("Média das idades: " + media);

            Console.WriteLine();

            double porcentagemHomens = (double)totalHomens / contador * 100;
            Console.WriteLine($"Quantidade de homens: {porcentagemHomens:F2}%");
            Console.WriteLine();
            double porcentagemMulheres = (double)totalMulheres / contador * 100;
            Console.WriteLine($"Quantidade de mulheres: {porcentagemMulheres:F2}%");

        }
        else
        {
            Console.WriteLine("Não houve nenhuma entrevista :(");
        }
    }

    private static void Ex4()
    {
        /*
        Dê a codificação completa da classe Aluno, de acordo com o diagrama fornecido.

        O método GetNotaFinal() deverá calcular e retornar a nota final do aluno, que consiste na média aritmética das três notas.
        O método GetResultado() deverá retornar um string contendo o resultado final do aluno, de acordo com a seguinte tabela:
        "Aprovado": nota final maior ou igual a 60 pontos.
        "Recuperação": nota final entre 40 e 59 pontos, inclusive.
        "Reprovado": nota inferior a 40 pontos. 
        */

        Aluno aluno = new Aluno(12202509, "Ana Clara", 65, 40, 70);
        
        Console.WriteLine("Matrícula do aluno: " + aluno.GetMatricula());
        Console.WriteLine("Nome do aluno: " + aluno.GetNome());
        Console.WriteLine("Média das notas: " + aluno.GetNotaFinal());
        Console.WriteLine("Resultado: " + aluno.GetResultado());
    }
    private static void Ex5()
    {
        /*
        Escreva a classe TestaAluno que deverá permitir o cadastro de N alunos, onde N será informado pelo usuário (dica: use um vetor de objetos). 
        Ao final, imprimir nome e resultado final dos N alunos.
        */

        Console.WriteLine("Digite a quantidade de cadastros que deseja realizar: ");
        int N = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        TestaAluno[] ArrayAlunos = new TestaAluno[N];

        for(int i = 0; i < N; i++)
        {
            Console.WriteLine("Digite o nome do aluno (a): ");
            string nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite o valor da 1° nota: ");
            double nota1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite o valor da 2° nota: ");
            double nota2= Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            TestaAluno aluno = new TestaAluno();
            aluno.setNome(nome);
            aluno.setNota1(nota1);
            aluno.setNota2(nota2);
            ArrayAlunos[i] = aluno;
        }
        Console.WriteLine("_________________________________________________");
        Console.WriteLine("Alunos cadastrados e seus respectivos resultados:");
        Console.WriteLine("-------------------------------------------------");

        for (int i = 0; i < ArrayAlunos.Length; i++) {
            Console.WriteLine($"O nome do aluno (a) é {ArrayAlunos[i].getNome()}");
            Console.WriteLine($"Nota 1: {ArrayAlunos[i].getNota1()} | Nota 2: {ArrayAlunos[i].getNota2()}");
            Console.WriteLine($"Média: {ArrayAlunos[i].getNotaFinal()}");
            Console.WriteLine($"Resultado Final: {ArrayAlunos[i].getResultado()}");
            Console.WriteLine();
        }
    }

    private static void Ex6()
    {
        /*
        Projete uma classe denominada Data que deverá armazenar dia, mês e ano como valores inteiros (não é permitido usar a classe DateTime ou similares). 
        Crie o método construtor, os métodos get e set, e um método para retornar a data como string, no formato "dd/mm/aaaa". 
        */

        Data data = new Data(29, 3, 2004);
        Console.WriteLine(data.retornarData());
    }
}



