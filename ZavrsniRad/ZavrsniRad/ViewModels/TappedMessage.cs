using GalaSoft.MvvmLight.Messaging;

namespace ZavrsniRad.ViewModels
{
    public class TappedMessage : MessageBase
    {
        public int Number { get; set; }

        public TappedMessage(int number)
        {
            Number = number;
        }
    }
}

