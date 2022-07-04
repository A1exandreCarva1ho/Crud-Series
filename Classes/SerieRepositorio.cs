using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio: IRepositorio<Serie>
    {

        private List<Serie> ListaSeries = new List<Serie>();

        public List<Serie> Lista(){
            return ListaSeries;
        }

        public Serie RetornaPorId(int id){
            return ListaSeries[id];
        }
        public void Insere(Serie entidade){
            ListaSeries.Add(entidade);
        }
        public void Exclui(int id){
            ListaSeries[id].Excluir();
        }

        public void Atualiza(int id, Serie entidade){
            ListaSeries[id] = entidade;
        }
        
        public int ProximoId(){
            return ListaSeries.Count;
        }

    }
}