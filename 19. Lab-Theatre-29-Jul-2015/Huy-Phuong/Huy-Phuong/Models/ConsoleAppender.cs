namespace Huy_Phuong.Models
{
    using System;
    using Interfaces;

    public class ConsoleAppender: IAppender
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
