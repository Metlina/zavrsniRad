using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Redux.Sample.Serialize
{
    public class WriteSerializer : ISerializer
    {
        public BinaryWriter Writer { get; set; }

        public void Serialize<T>(Func<T> get, Action<T> set)
        {
            if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                throw new InvalidOperationException(string.Format("Enumerable types such as '{0}' must be serialized with the SerializeList method", typeof(T).FullName));
            }

            var value = get();

            if (typeof(IBinarySerializable).GetTypeInfo().IsAssignableFrom(typeof(T).GetTypeInfo()))
            {
                if (typeof(T).GetTypeInfo().IsClass)
                {
                    // ReSharper disable once CompareNonConstrainedGenericWithNull
                    // checked if class
                    if (value == null)
                    {
                        Writer.Write(false);
                        return;
                    }

                    Writer.Write(true);
                }

                // ReSharper disable once PossibleNullReferenceException
                // checked above
                Writer.Write(value.GetType().AssemblyQualifiedName);
                ((IBinarySerializable)value).Serialize(this);

                return;
            }

            // serialize enum as Int32
            if (typeof(T).GetTypeInfo().IsEnum)
            {
                object intWriter;
                if (SerializerHelper.TypeWriters.TryGetValue(typeof(Int32), out intWriter))
                {
                    ((Action<BinaryWriter, Int32>)intWriter)(Writer, Convert.ToInt32(value));
                    return;
                }
            }

            object typeWriter;
            if (SerializerHelper.TypeWriters.TryGetValue(typeof(T), out typeWriter))
            {
                ((Action<BinaryWriter, T>)typeWriter)(Writer, value);
                return;
            }

            throw new InvalidOperationException(string.Format("No writer exists for type '{0}", typeof(T).FullName));
        }

        public void Serialize<T>(Func<T?> get, Action<T?> set) where T : struct
        {
            var value = get();
            Writer.Write(value.HasValue);

            if (value.HasValue)
            {
                Serialize(() => value.Value, null);
            }
        }

        public void SerializeList<T>(Func<List<T>> get, Action<List<T>> set)
        {
            var value = get();
            Writer.Write(value != null);

            if (value == null) return;

            Writer.Write(value.Count);

            foreach (var element in value)
            {
                var copy = element;
                Serialize(() => copy, null);
            }
        }

        public void Serialize(Func<string> read, Action<string> write)
        {
            Writer.Write(read() ?? string.Empty);
        }
    }
}