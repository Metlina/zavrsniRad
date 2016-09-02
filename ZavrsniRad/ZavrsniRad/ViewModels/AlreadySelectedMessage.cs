using System;
using GalaSoft.MvvmLight.Messaging;

namespace ZavrsniRad.ViewModels
{
    public class AlreadySelectedMessage : MessageBase
    {
        public int Number { get; set; }

        public AlreadySelectedMessage(int number)
        {
            Number = number;
        }
    }
}

