using System;
using System.Collections.Generic;
using System.Text;

namespace ClassModellator.MysqlClassModellator.Interface
{
    internal interface IDBConnector
    {

        PropertyModellator PropConnessione();

        functionModellator getConnectionStringFunction();
    }
}
