using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Comida 
{
    class Plato
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Tipo { get; set; }
        public bool Gluten { get; set; }
        public bool Soja { get; set; }
        public bool Leche { get; set; }
        public bool Sulfitos { get; set; }

        public Plato(string nombre, string imagen, string tipo, bool gluten, bool soja, bool leche, bool sulfitos)
        {
            Nombre = nombre;
            Imagen = imagen;
            Tipo = tipo;
            Gluten = gluten;
            Soja = soja;
            Leche = leche;
            Sulfitos = sulfitos;
        }

        public Plato()
        {
        }

        public static ObservableCollection<Plato> GetSamples(string rutaImagenes)
        {
            ObservableCollection<Plato> lista = new ObservableCollection<Plato>();
            lista.Add(new Plato("Hamburguesa", Path.Combine(rutaImagenes, @"burguer.jpg"), "Americana", true, false, true, true));
            lista.Add(new Plato("Dumplings", Path.Combine(rutaImagenes, @"dumplings.jpg"), "China", true, true, false, false));
            lista.Add(new Plato("Tacos", Path.Combine(rutaImagenes, @"tacos.jpg"), "Mexicana", true, false, false, true));
            lista.Add(new Plato("Cerdo agridulce", Path.Combine(rutaImagenes, @"cerdoagridulce.jpg"), "China", true, true, false, true));
            lista.Add(new Plato("Hot dogs", Path.Combine(rutaImagenes, @"hotdog.jpg"), "Americana", true, true, true, true));
            lista.Add(new Plato("Fajitas", Path.Combine(rutaImagenes, @"fajitas.jpg"), "Mexicana", true, false, false, true));
            return lista;
        }
    }



}
