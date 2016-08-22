using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Redux.Sample.Serialize
{
    public class ReadSerializer : ISerializer
    {
        public BinaryReader Reader { get; set; }

        public void Serialize<T>(Func<T> get, Action<T> set)
        {
            if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException(string.Format("Enumerable types such as '{0}' must be serialized with the SerializeList method", typeof(T).FullName));
            }

            if (typeof(IBinarySerializable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                if (typeof(T).GetTypeInfo().IsClass)
                {
                    var hasValue = Reader.ReadBoolean();
                    if (!hasValue)
                    {
                        return;
                    }
                }

                var implementationTypeName = Reader.ReadString();
                Type implementationType = Type.GetType(implementationTypeName, false);
                if (implementationType != null && typeof(T).GetTypeInfo().IsAssignableFrom(implementationType.GetTypeInfo()))
                {
                    var value = Activator.CreateInstance(Type.GetType(implementationTypeName));
                    ((IBinarySerializable)value).Serialize(this);
                    set((T)value);
                }

                return;
            }

            // deserialize enum from Int32
            if (typeof(T).GetTypeInfo().IsEnum)
            {
                object intReader;
                if (SerializerHelper.TypeReaders.TryGetValue(typeof(Int32), out intReader))
                {
                    int value = ((Func<BinaryReader, Int32>)intReader)(Reader);
                    set((T)Enum.ToObject(typeof(T), value));
                    return;
                }
            }

            object typeReader;
            if (SerializerHelper.TypeReaders.TryGetValue(typeof(T), out typeReader))
            {
                set(((Func<BinaryReader, T>)typeReader)(Reader));
                return;
            }

            throw new InvalidOperationException(string.Format("No reader exists for type '{0}", typeof(T).FullName));
        }

        public void Serialize<T>(Func<T?> get, Action<T?> setNullable) where T : struct
        {
            var hasValue = Reader.ReadBoolean();
            if (!hasValue)
            {
                setNullable(null);
                return;
            }

            Serialize<T>(null, set: v => setNullable(v));
        }

        public void SerializeList<T>(Func<List<T>> get, Action<List<T>> set)
        {
            var hasValue = Reader.ReadBoolean();

            var list = new List<T>();
            if (!hasValue)
            {
                set(list);
                return;
            }

            var count = Reader.ReadInt32();

            for (var i = 0; i < count; ++i)
            {
                Serialize<T>(null, list.Add);
            }

            set(list);
        }

        public void Serialize(Func<string> get, Action<string> set)
        {
            set(Reader.ReadString());
        }
    }
}