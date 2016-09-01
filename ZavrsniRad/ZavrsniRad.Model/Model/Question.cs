using ZavrsniRad.Model.Serialization;

namespace ZavrsniRad.Model.Model
{
    public enum Category
    {
        Easy,
        Medium,
        Hard
    }
    public class Question : IBinarySerializable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public int CorrectAnswer { get; set; }
        public Category Category { get; set; }

        public void Serialize(ISerializer serializer)
        {
            serializer.Serialize(() => Text, v => Text = v);
            serializer.Serialize(() => FirstAnswer, v => FirstAnswer = v);
            serializer.Serialize(() => SecondAnswer, v => SecondAnswer = v);
            serializer.Serialize(() => ThirdAnswer, v => ThirdAnswer = v);
            serializer.Serialize(() => CorrectAnswer, v => CorrectAnswer = v);
            serializer.Serialize(() => Category, v => Category = v);
        }
    }
}