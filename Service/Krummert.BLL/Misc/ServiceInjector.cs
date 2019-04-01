using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Krummert.BLL.Misc
{
    public static class ServiceInjector
    {
        public static void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            var extanciatedTypes = new Dictionary<string, KeyValuePair<Type, object>>();
            extanciatedTypes.Add(typeof(IConfiguration).AssemblyQualifiedName, new KeyValuePair<Type, object>(typeof(IConfiguration), configuration));

            AddArrayToInjection(GetAllTypesInNamespace("Krummert.DLL.DB"), extanciatedTypes);
            AddArrayToInjection(GetAllTypesInNamespace("Krummert.BLL.Services"), extanciatedTypes);

            foreach (var key in extanciatedTypes.Keys)
            {
                services.AddSingleton(extanciatedTypes[key].Key, extanciatedTypes[key].Value);
            }
        }

        private static void AddArrayToInjection(List<Type> typesToExtanciate, Dictionary<string, KeyValuePair<Type, object>> extanciatedTypes)
        {
            while (typesToExtanciate.Count > 0)
            {
                for (var i = 0; i < typesToExtanciate.Count;)
                {
                    foreach (var constructor in typesToExtanciate[i].GetConstructors())
                    {
                        var paramaters = constructor.GetParameters();
                        var paramterNames = paramaters.Select(m => m.ParameterType.AssemblyQualifiedName).ToArray();

                        var doWeHaveAllOfTheParamaters = true;
                        foreach (var name in paramterNames)
                        {
                            if (!extanciatedTypes.ContainsKey(name))
                            {
                                doWeHaveAllOfTheParamaters = false;
                                break;
                            }
                        }

                        if (doWeHaveAllOfTheParamaters)
                        {
                            var valuesForConstructor = new List<object>();

                            foreach (var paramater in paramaters)
                            {
                                valuesForConstructor.Add(extanciatedTypes[paramater.ParameterType.AssemblyQualifiedName].Value);
                            }
                            
                            extanciatedTypes.Add(typesToExtanciate[i].AssemblyQualifiedName, new KeyValuePair<Type, object>(typesToExtanciate[i], constructor.Invoke(valuesForConstructor.ToArray())));
                            typesToExtanciate.Remove(typesToExtanciate[i]);
                        }
                        else
                        {
                            i++;
                        }

                        break;
                    }
                }
            }
        }
        private static List<Type> GetAllTypesInNamespace(string nameSpace)
        {
            var namespaceList = new List<Type>();
            foreach (Type type in Assembly.GetAssembly(typeof(DLL.DB.UserRepository)).GetTypes().Union(Assembly.GetAssembly(typeof(Services.UserService)).GetTypes()).Where(type => type.Namespace == nameSpace))
            {
                if ((!type.IsInterface) && (!type.Name.Contains("<>")))
                {
                    namespaceList.Add(type);
                }
            }

            return namespaceList;
        }
    }
}
