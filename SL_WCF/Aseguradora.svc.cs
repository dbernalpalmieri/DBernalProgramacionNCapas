using ML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Aseguradora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Aseguradora.svc o Aseguradora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Aseguradora : IAseguradora
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Object = result.Object,
                Objects = result.Objects,
                Exeption = result.Exeption
            };
        }

        public SL_WCF.Result GetById(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetById(IdAseguradora);

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Object = result.Object,
                Objects = result.Objects,
                Exeption = result.Exeption
            };
        }

        public SL_WCF.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Add(aseguradora);

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Object = result.Object,
                Objects = result.Objects,
                Exeption = result.Exeption
            };
        }

        public SL_WCF.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Update(aseguradora);

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Object = result.Object,
                Objects = result.Objects,
                Exeption = result.Exeption
            };
        }

        public SL_WCF.Result Delete(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.Delete(IdAseguradora);

            return new SL_WCF.Result
            {
                Correct = result.Correct,
                Message = result.Message,
                Object = result.Object,
                Objects = result.Objects,
                Exeption = result.Exeption
            };
        }

        public class SvcErrorHandlerBehaviourAttribute : Attribute, IServiceBehavior
        {
            public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            { } //implementation not needed

            public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
                                             BindingParameterCollection bindingParameters)
            { } //implementation not needed

            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
                foreach (ChannelDispatcherBase chanDispBase in serviceHostBase.ChannelDispatchers)
                {
                    ChannelDispatcher channelDispatcher = chanDispBase as ChannelDispatcher;
                    if (channelDispatcher == null)
                        continue;
                    channelDispatcher.ErrorHandlers.Add(new SvcErrorHandler());
                }
            }
        }

        public class SvcErrorHandler : IErrorHandler
        {
            public bool HandleError(Exception error)
            {
                //You can log th message if you want.
                return true;
            }

            public void ProvideFault(Exception error, MessageVersion version, ref Message msg)
            {
                if (error is FaultException)
                    return;

                FaultException faultException = new FaultException(error.Message);
                MessageFault messageFault = faultException.CreateMessageFault();
                msg = Message.CreateMessage(version, messageFault, faultException.Action);
            }
        }
    }

}
