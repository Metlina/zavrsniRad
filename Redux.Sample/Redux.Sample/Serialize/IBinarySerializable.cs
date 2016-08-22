namespace Redux.Sample.Serialize
{
    public interface IBinarySerializable
    {
        void Serialize(ISerializer serializer);
    }
}
