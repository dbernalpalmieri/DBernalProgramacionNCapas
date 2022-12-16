using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ML;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAseguradora" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAseguradora
    {
        [OperationContract]
        // Definimos el tipo de objeto al cual serán deseralizados los objects que retorna nuestro método
        [ServiceKnownType(typeof(ML.Aseguradora))] // 
        SL_WCF.Result GetAll();


        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF.Result GetById(int IdAseguradora);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF.Result Add(ML.Aseguradora aseguradora);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Result))]
        SL_WCF.Result Update(ML.Aseguradora aseguradora);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Result))]
        SL_WCF.Result Delete(int IdAseguradora);

    }
}
