using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Serie: EntidadeBase
    {
        public Genero genero {get;set;}
        public string titulo{get;set;}
        public string descricao{get;set;}
        public int ano{get;set;}

        private bool registroExcluido;

        public Serie(int id,
                     Genero genero,
                     string titulo,
                     string descricao,
                     int ano){

         this.genero = genero;
         this.titulo = titulo;
         this.descricao = descricao;
         this.ano = ano;
         this.registroExcluido = false;               
        }

        public override string ToString()
        {
            string retorno  = "";
            retorno += "Genero:" + this.genero + Environment.NewLine;
            retorno += "Título:" + this.genero + Environment.NewLine;
            retorno += "Descrição:" + this.genero + Environment.NewLine;
            retorno += "Ano:" + this.genero + Environment.NewLine;
            retorno += "excluido:" + this.registroExcluido + Environment.NewLine;
            return retorno;
        }

        public string RetornaTitulo(){
            return this.titulo;
        }


        public int RetornaID(){
            return this.id;
        }
        public bool RetornaExcluido(){
            return this.registroExcluido;
        }

        public void Excluir(){
            registroExcluido = true;
        }
    }
}