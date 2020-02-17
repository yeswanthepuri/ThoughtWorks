using System;


namespace Program_Schedule
{
    public static class ExceptionHandling
    {
        public static Exception Excep { get; set; }
        static ExceptionHandling()
        {
            Excep=new Exception();
        }
    }
}
