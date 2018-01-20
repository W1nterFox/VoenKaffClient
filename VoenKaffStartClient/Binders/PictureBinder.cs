using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace VoenKaffStartClient.Binders
{
    public class PictureBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly currentasm = Assembly.GetExecutingAssembly();

            return Type.GetType($"{currentasm.GetName().Name}.{typeName.Split('.')[1]}");
        }
    }
}
