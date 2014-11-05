using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using it.furinfo.pompa.Entities;

namespace it.furinfo.pompa.DataLayer.Table.Mapping
{
   public class configurations
    {
       MachineType _machineType;

       public MachineType MachineType
        {
            get { return _machineType; }
            set { _machineType = value; }
        }

        int _dataReadingTiming;

        public int DataReadingTiming
        {
            get { return _dataReadingTiming; }
            set { _dataReadingTiming = value; }
        }

        int _dataSavingTiming;

        public int DataSavingTiming
        {
            get { return _dataSavingTiming; }
            set { _dataSavingTiming = value; }
        }

        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }  


        public configurations()
        {
        }
    }
}
