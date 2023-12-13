using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace CrazyTeam.DarkMagick
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Ruft die ToString-Methode für ein Objekt aus, welches nicht NULL ist, und gibt ansonsten string.Empty zurück.
        /// </summary>
        /// <param name="objThis">Das Objekt, welches in einen String umgewandelt werden soll.</param>
        /// <returns>objThis.ToString(), wenn objThis ungleich NULL ist. Ansonsten string.Empty.</returns>
        public static string ToStringNullsafe(this object objThis)
        {
            return (objThis == null ? string.Empty : objThis.ToString());
        }
        /// <summary>
        /// Castet ein Objekt zu Bool, wenn dieses nicht NULL und ein gültiger Boolean-Wert ist. Ansonsten wird der Standardwert für Boolean zurückgegeben.
        /// </summary>
        /// <param name="objThis">Das Objekt, welches zu einem Boolean gecastet werden soll.</param>
        /// <returns>Das übergebene Objekt als Boolean, wenn dieses ein gültiger Boolean ist, ansonsten den Standardwert für Booleans.</returns>
        public static bool ToBoolNullsafe(this object objThis)
        {
            bool bolReturn = default(bool);

            if (objThis != null)
            {
                try
                {
                    bolReturn = (bool)objThis;
                }
                catch (InvalidCastException)
                {
                    bolReturn = default(bool);
                }
            }

            return bolReturn;
        }

        public static object CloneDeep(this object obj)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));
                binaryFormatter.Serialize(memStream, obj);
                memStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memStream);
            }
        }

        public static bool EqualsNullsafe(Object o1, Object o2) {
            if (o1 == null && o2 == null) return true;
            if ((o1 == null && o2 != null) || (o2 == null && o1 != null)) return false;
            return o1.Equals(o2);
        }
        

      

        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
