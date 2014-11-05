using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using it.furinfo.pompa.Entities;

namespace it.furinfo.pompa.DataLayer.Table.Mapping
{
    [Serializable]
    public class pumpParam
    {
        MachineType _punpId;
        public MachineType PunpId
        {
            get { return _punpId; }
            set { _punpId = value; }
        }
        

        double _pistonStroke;

        /// <summary>
        /// Corsa
        /// </summary>
        public double PistonStroke
        {
            get { return _pistonStroke; }
            set { _pistonStroke = value; }
        }

        double _diameter;
        /// <summary>
        /// Diametro
        /// </summary>
        public double Diameter
        {
            get { return _diameter; }
            set { _diameter = value; }
        }

        int _pistonNumber;
        /// <summary>
        /// Numero pistoni
        /// </summary>
        public int PistonNumber
        {
            get { return _pistonNumber; }
            set { _pistonNumber = value; }
        }


        int _maxStroke;
        /// <summary>
        /// Numero massimo colpi pompa
        /// </summary>
        public int MaxStroke
        {
            get { return _maxStroke; }
            set { _maxStroke = value; }
        }

        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }        
    }
}
