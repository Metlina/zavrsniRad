using System;
using System.Collections.Generic;
using System.IO;

namespace Redux.Sample.Serialize
{
    internal static class SerializerHelper
    {
        public static Dictionary<Type, object> TypeReaders { get; private set; }
        public static Dictionary<Type, object> TypeWriters { get; private set; }

        static SerializerHelper()
        {
            TypeReaders = new Dictionary<Type, object>
            {
                {typeof (bool), (Func<BinaryReader, bool>) (reader => reader.ReadBoolean())},
                {typeof (Int16), (Func<BinaryReader, Int16>) (reader => reader.ReadInt16())},
                {typeof (Int32), (Func<BinaryReader, Int32>) (reader => reader.ReadInt32())},
                {typeof (Int64), (Func<BinaryReader, Int64>) (reader => reader.ReadInt64())},
                {typeof (UInt16), (Func<BinaryReader, UInt16>) (reader => reader.ReadUInt16())},
                {typeof (UInt32), (Func<BinaryReader, UInt32>) (reader => reader.ReadUInt32())},
                {typeof (UInt64), (Func<BinaryReader, UInt64>) (reader => reader.ReadUInt64())},
                {typeof (byte), (Func<BinaryReader, byte>) (reader => reader.ReadByte())},
                {typeof (char), (Func<BinaryReader, char>) (reader => reader.ReadChar())},
                {typeof (decimal), (Func<BinaryReader, decimal>) (reader => reader.ReadDecimal())},
                {typeof (double), (Func<BinaryReader, double>) (reader => reader.ReadDouble())},
                {typeof (float), (Func<BinaryReader, float>) (reader => reader.ReadSingle())},
                {typeof (DateTime), (Func<BinaryReader, DateTime>) (reader => new DateTime(reader.ReadInt64()))},
            };

            TypeWriters = new Dictionary<Type, object>
            {
                {typeof (bool), (Action<BinaryWriter, bool>) ((writer, value) => writer.Write(value))},
                {typeof (Int16), (Action<BinaryWriter, Int16>) ((writer, value) => writer.Write(value))},
                {typeof (Int32), (Action<BinaryWriter, Int32>) ((writer, value) => writer.Write(value))},
                {typeof (Int64), (Action<BinaryWriter, Int64>) ((writer, value) => writer.Write(value))},
                {typeof (UInt16), (Action<BinaryWriter, UInt16>) ((writer, value) => writer.Write(value))},
                {typeof (UInt32), (Action<BinaryWriter, UInt32>) ((writer, value) => writer.Write(value))},
                {typeof (UInt64), (Action<BinaryWriter, UInt64>) ((writer, value) => writer.Write(value))},
                {typeof (byte), (Action<BinaryWriter, byte>) ((writer, value) => writer.Write(value))},
                {typeof (char), (Action<BinaryWriter, char>) ((writer, value) => writer.Write(value))},
                {typeof (decimal), (Action<BinaryWriter, decimal>) ((writer, value) => writer.Write(value))},
                {typeof (double), (Action<BinaryWriter, double>) ((writer, value) => writer.Write(value))},
                {typeof (float), (Action<BinaryWriter, float>) ((writer, value) => writer.Write(value))},
                {typeof (DateTime), (Action<BinaryWriter, DateTime>) ((writer, value) => writer.Write(value.Ticks))},
            };
        }
    }
}