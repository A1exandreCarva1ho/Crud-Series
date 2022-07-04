using System;
using DIO.Series;

namespace DIO.Series{
    class Program{

        static SerieRepositorio repositorio = new SerieRepositorio();


        static void Main (string[] Args){
           string usuario =  ObterOpcaoUsuario();

           while (usuario.ToUpper()!= "X"){
                switch(usuario){
                    case "1": ListarSeries();
                    break;
                    case "2": AddSerie();
                    break;
                    case "3": AtualizarSerie();
                    break;
                    case "4": ExcluirSerie();
                    break;
                    case "5": VisualizarSerie();
                    break;
                    case "C": LimparTela();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();                           
                }
           };
        }

        private static void ListarSeries(){

            Console.WriteLine("Essas são as nossas series:");
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Não existe nenhuma serie cadastrada no momento!");
                return;
            }


            foreach (Serie serie in lista){
                var excluido = serie.RetornaExcluido();
                if(!excluido){
                Console.WriteLine("#ID: {0} - {1}",serie.RetornaID(),serie.RetornaTitulo());
                }
            }
        }
        private static void LimparTela()
        {
         Console.Clear();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Insira o ID da série a excluir:");
            int entradaId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Deseja confirmar a exclusão? (Y/N):");
            string entradaConfirmacao = Console.ReadLine().ToUpper();
            switch(entradaConfirmacao){
                case "Y": repositorio.Exclui(entradaId);
                break;
                case"N":Console.WriteLine("Acao cancelada");
                break;
                default:  Console.WriteLine("Escolha uma opcao valida (Y/N)");
                ExcluirSerie();
                break;
            }
            
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Insira o ID da série a visualizar:");
            int entradaId = int.Parse(Console.ReadLine());
            var serie  = repositorio.RetornaPorId(entradaId);
            Console.WriteLine(serie);
            
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar cadastro de  série");
            Console.WriteLine("Insira o ID da série a atualizar");
            int entradaId = int.Parse(Console.ReadLine());


            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("#ID: {0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero do filme");

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do filme");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao do filme");
            string entradaDescricao = Console.ReadLine();


            Serie novaSerie = new Serie(entradaId,
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Atualiza(entradaId,novaSerie);
        }

        private static void AddSerie()
        {
            Console.WriteLine("inserir nova série");


            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("#ID: {0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero do filme");

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano do filme");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao do filme");
            string entradaDescricao = Console.ReadLine();


            Serie novaSerie = new Serie(repositorio.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao,
                                        entradaAno);

            repositorio.Insere(novaSerie);

        }

            private static string ObterOpcaoUsuario(){
                Console.WriteLine();
                Console.WriteLine("DIO Series ao seu dispor");
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine("1-Listar series");
                Console.WriteLine("2-Adicionar nova serie");
                Console.WriteLine("3-Atualizar serie");
                Console.WriteLine("4-Excluir serie");
                Console.WriteLine("C-Limpar tela");
                Console.WriteLine("X-Sair");
                Console.WriteLine("");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
    }
}
