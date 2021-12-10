using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JsonService : ObservableObject
{
    ObservableCollection<Pelicula> lista = new ObservableCollection<Pelicula>();

    public void Exportar(string ruta)
    {
        string peliculasJson = JsonConvert.SerializeObject(lista);
        File.WriteAllText(ruta, peliculasJson);
    }
    public void Importar(string ruta)
    {
        string peliculasJson = File.ReadAllText(ruta);
        lista = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
    }

}

