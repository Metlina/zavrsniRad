using ZavrsniRad.Model.Model;
using ZavrsniRad.Model.Serialization;

namespace ZavrsniRad.Model.Data
{
    public class QuestionData : BaseStore
    {
        public Question Question { get; set; }

        public QuestionData() : base ("question.data")
        {
            Question = new Question();
        }

        public override void Serialize(ISerializer serializer)
        {
            serializer.Serialize(() => Question, v => v = Question = v);
        }

        public override void Cleanup()
        {
            Question = new Question();
        }
    }
}

