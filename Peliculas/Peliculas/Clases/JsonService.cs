using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas
{
    class JsonService : ObservableObject
    {

        public void Exportar(string ruta, ObservableCollection<Pelicula> lista)
        {
            string peliculasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText(ruta, peliculasJson);
        }
        public ObservableCollection<Pelicula> Importar(string ruta)
        {
            string peliculasJson = File.ReadAllText(ruta);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        }
    }
}


