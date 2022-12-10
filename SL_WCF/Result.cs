using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SL_WCF
{
    public class Result
    {
        bool correct;
        string message;
        Exception exeption;
        object _object;
        List<object> objects;

        [DataMember] // Permite la serializacion del atributo, (Parsesearlo a XML en este caso) 
        public bool Correct { get => correct; set => correct = value; }
        [DataMember]
        public string Message { get => message; set => message = value; }
        [DataMember]
        public Exception Exeption { get => exeption; set => exeption = value; }
        [DataMember]
        public object Object { get => _object; set => _object = value; }
        [DataMember]
        public List<object> Objects { get => objects; set => objects = value; }
    }
}