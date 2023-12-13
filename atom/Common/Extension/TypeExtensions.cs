using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;


namespace ATom.CommonBasics.Extension
{
    static public class TypeExtensions
    {
        static private Dictionary<string, Type> dictTypes = new Dictionary<string, Type>();

        private static object monitor = new object();

        /// <summary>
        /// This method gets the final sub-class from a type.
        /// If A is derived from B and B is derived from C and you call this method with parameter C you get A as Result.
        /// If additional D is derived from B too, and you call it with C you get A and D as Result.
        /// Maybe we need a better name for this method!
        /// </summary>
        /// <param name="type">type you want to find subclasses for</param>
        /// <returns>HashSet of 'final' subclass types</returns>
        public static HashSet<Type> GetFinalSubTypes(this Type type,TypesSelection typeSelection = TypesSelection.ClassAndInterface, List<Assembly> assemblies = null)
        {
            HashSet<Type> masterTypes=new HashSet<Type>();
            GetFinalSubTypes(type, masterTypes,typeSelection,assemblies);
            return masterTypes;
        }

        public static bool IsNumeric(this Type t)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        private static void GetFinalSubTypes(Type type, HashSet<Type> masterTypes, TypesSelection typeSelection = TypesSelection.ClassAndInterface, List<Assembly> assemblies = null) {
            IEnumerable<Type> types = type.GetSubTypes(typeSelection,assemblies);
            if (types.Count() == 0 && ((((int)TypesSelection.Class & (int)typeSelection) != 0 && type.IsClass) || (((int)TypesSelection.Interface & (int)typeSelection) != 0 && type.IsInterface))) masterTypes.Add(type);
            else
                foreach (Type type1 in types)
                {
                    GetFinalSubTypes(type1, masterTypes,typeSelection,assemblies);
                }
        }

        public static IEnumerable<Type> GetSubTypes(this Type type, List<Assembly> assemblies = null)
        {
            return GetSubTypes(type,TypesSelection.ClassAndInterface,assemblies);
        }

        public static IEnumerable<Type> GetSubTypes(this Type type, TypesSelection typeSelection = TypesSelection.ClassAndInterface,List<Assembly> assemblies=null )
        {
            return GetTypesWhere(_ => (_.BaseType == type || _.GetInterfaces().Contains(type)) && ((((int)TypesSelection.Class&(int)typeSelection)!=0 && _.IsClass) || (((int)TypesSelection.Interface & (int)typeSelection) != 0 && _.IsInterface)),assemblies);
        }

        public static IEnumerable<Type> GetImplementingTypes(this Type interfaceType)
        {
            return GetTypesWhere(_ => interfaceType.IsAssignableFrom(_) && !_.IsInterface);
        }

        public static List<Type> GetTypesWhere(Func<Type, bool> predicate, List<Assembly> assemblies = null) {
            List<Type> types = new List<Type>();
            foreach (Assembly assembly in assemblies??AssembliesControllerBox) {
                types.AddRange(assembly.GetTypes().Where(predicate));
            }
            return types;
        }

       

        private static List<Assembly> assemblies;

        /* private static List<Assembly> Assemblies {
             get {
                 if (assemblies == null) {
                     assemblies=new List<Assembly>();
                     foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                         try {
                             FileVersionInfo version = FileVersionInfo.GetVersionInfo(assembly.Location);
                             if (version != null && version.CompanyName != null && version.CompanyName.ToLower().Contains("controllerbox")) {
                                 assemblies.Add(assembly);
                             } else if (assembly.FullName.Contains("Droid") || assembly.FullName.Contains("iOS"))
                                 assemblies.Add(assembly);                        
                     } catch (NotSupportedException ex) {
                             assemblies.Add(assembly); //Is internal Assembly then...
                         } catch (Exception ex) {
                             CBLog.Error("Could not get Info on Assembly "+assembly,ex);
                         }
                     }    
                 }
                 return assemblies;
             }
         }*/

        private static object _monitor_assemblies = new object();

        public static List<Assembly> AssembliesControllerBox
        {
            get
            {
                lock (_monitor_assemblies)
                {
                    if (assemblies == null) {
                        assemblies = new List<Assembly>();
#if MOBILE && !CREATE_DB
                        assemblies.Add(Assembly.GetExecutingAssembly());
#else
                        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                                try {
                                    assembly.GetTypes().FirstOrDefault();
                                    assemblies.Add(assembly);
                                }
                                catch (Exception ex) {
                                    //CBLog.Info("Could not get Info on Assembly " + assembly, ex); //TODO-Antth logging einbauen!
                                }
                            }
#endif
                    }                 
                }
                return assemblies;
            }
        }

        private static List<Assembly> assembliesForType;

        public static List<Assembly> AssembliesForLookupType
        {
            get
            {

#if MOBILE && !CREATE_DB
                       if (assembliesForType==null) {
                    assembliesForType= new List<Assembly>();


                        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                                try {
                                    assembly.GetTypes().FirstOrDefault();
                        assembliesForType.Add(assembly);
                                }
                                catch (Exception ex) {
                                    CBLog.Info("Could not get Info on Assembly " + assembly, ex);
                                }
                            }
                    }
                return assembliesForType;
#else
                return AssembliesControllerBox;
#endif
            }                
        }



        public static Type FindType(String typeName) {
            Type t = Type.GetType(typeName);
            if (t != null) return t;
            lock (monitor) {
                if (!dictTypes.ContainsKey(typeName)) {
//#if MONO
//                dictTypes[typeName] = Assembly.GetCallingAssembly().GetType(typeName);
//#else
                    dictTypes[typeName] = AssembliesForLookupType.SelectMany(assembly => assembly.GetTypes()).FirstOrDefault(type => type.FullName.Equals(typeName));
//#endif
                }
                return dictTypes[typeName];
            }
        }

        public static bool IsNumericType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public enum TypesSelection {
            Class = 0x1,
            Interface = 0x2,
            ClassAndInterface = 0x3            
        }
    }
}
