﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesMVVM
{
    class MainWindowVM : ObservableObject
    {
        SuperheroeService sps;
        private ObservableCollection<Superheroe> heroes;

        private Superheroe heroeActual;

        public Superheroe HeroeActual
        {
            get { return heroeActual; }
            set { SetProperty(ref heroeActual, value); }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }

        private int actual;

        public int Actual
        {
            get { return actual; }
            set { SetProperty(ref actual, value); }
        }


        public MainWindowVM()
        {
            sps = new SuperheroeService();
            heroes = sps.GetSamples();
            HeroeActual = heroes[0];
            Total = heroes.Count;
            Actual = 1;
            SiguienteCommand = new RelayCommand(Siguiente);
            AnteriorCommand = new RelayCommand(Anterior);
        }

        public RelayCommand SiguienteCommand { get; }
        public RelayCommand AnteriorCommand { get; }

        public void Siguiente()
        { 
            if (Actual < Total)
            {
                Actual++;
                HeroeActual = heroes[Actual-1];
            }
        }

        public void Anterior()
        {
            if (Actual > 1)
            {
                Actual--;
                HeroeActual = heroes[Actual-1];
            }
        }

    }
}
