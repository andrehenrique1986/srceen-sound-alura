using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScreenSound
{
    class Program
    {
        static void Main(string[] args)
        {
            string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
            //List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Rolling Stones", "Aero Smith", "Guns 'N Roses" };
            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
            bandasRegistradas.Add("Link Park", new List <int>{ 10, 8, 6 });
            bandasRegistradas.Add("Rolling Stones", new List<int> ());

            // Screen Sound
            void ExibirLogo()
            {
                    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
                    Console.WriteLine("\n");
                    
                    Console.WriteLine(mensagemDeBoasVindas);
                    
            }

            void ExibirOpcoesDoMenu()
            {
                ExibirLogo();
                Console.WriteLine("\nDigite 1 para registar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a média de uma banda");
                Console.WriteLine("digite -1 para sair");

                Console.Write("\nDigite a sua opção: ");
                string opcaoEscolhida = Console.ReadLine()!;
                int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

                switch (opcaoEscolhidaNumerica)
                {
                    case 1: RegistrarBandas();
                        break;
                    case 2: MostrarBandasRegistradas();
                        break;
                    case 3: AvaliarUmaBanda();
                        break;
                    case 4: ExibirMediaDaBanda();
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau :)"); 
                        break;
                    default: Console.WriteLine("Opção Inválida");
                        break;
                }
            }

            void RegistrarBandas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Registro das Bandas");
                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine()!;
                bandasRegistradas.Add(nomeDaBanda, new List<int>());
                Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso !!!");
                Thread.Sleep(2000);
                Console.Clear();
                ExibirOpcoesDoMenu();

            }

            void MostrarBandasRegistradas()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação.");
                //for (int i = 0; i < listaDasBandas.Count; i++)
                //{
                //    Console.Write($"\nBanda: {listaDasBandas[i]}");
                //}
                foreach (string banda in bandasRegistradas.Keys)
                {
                    Console.Write($"\nBanda: {banda}\n");
                }
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            void ExibirTituloDaOpcao(string titulo) {

                int quantidadeDeLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");

                
            }

            void AvaliarUmaBanda()
            {
                // Digite qual banda deseja avaliar

                // Se a banda existir no dicionário >> atribuir uma nota

                // Senão, volta ao menu principal

                Console.Clear();
                ExibirTituloDaOpcao("Avaliar banda");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine()!;

                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"\nQual a nota que a banda {nomeDaBanda} merece ? ");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasRegistradas[nomeDaBanda].Add(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                } else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada !!!");
                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();

                }
            }

            void ExibirMediaDaBanda()
            {
                Console.Clear();
                ExibirTituloDaOpcao("Exibir média da banda");
                Console.Write("Digite o nome da banda que deseja exibir a média: ");
                string nomeDaBanda = Console.ReadLine();
                if (bandasRegistradas.ContainsKey(nomeDaBanda))
                {
                    List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
                    Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();

                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada !!!");
                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
               
            }

            ExibirOpcoesDoMenu();
            
        }
    }
}
