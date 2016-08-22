using System;
using System.Collections.Generic;

namespace Redux.Sample.Serialize
{
    public interface ISerializer
    {
        /// <summary>
        /// Serialize any value. If T implements IBinarySerializable, it will recursively
        /// serialize subobjects.
        /// </summary>
        void Serialize<T>(Func<T> get, Action<T> set);

        /// <summary>
        /// Special handling for nullable types.
        /// </summary>
        void Serialize<T>(Func<T?> get, Action<T?> set) where T : struct;

        /// <summary>
        /// List serialization is slightly complex.
        /// </summary>
        void SerializeList<T>(Func<List<T>> get, Action<List<T>> set);

        /// <summary>
        /// String serialization is also done via different method.
        /// </summary>
        void Serialize(Func<string> get, Action<string> set);
    }
}