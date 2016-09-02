namespace ZavrsniRad.Model.Model
{
    public enum Category
    {
        Easy,
        Medium,
        Hard
    }
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public int CorrectAnswer { get; set; }
        public Category Category { get; set; }
    }
}