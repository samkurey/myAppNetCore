using System;

namespace myAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine("the time now is:" + System.DateTime.Now);
                
                mytest test = new mytest();
                test.ConvertJpgtoBase64("photoinput.jpg","base64.bin");

                Console.WriteLine("done");
               // Console.ReadLine();
            }
            catch(Exception error)
            {
                Console.Write(error.Message);
            }
        }
    }

    public class mytest
    {
        public void ConvertJpgtoBase64(string input,string output)
        {
            byte[] jpgbuff = System.IO.File.ReadAllBytes(input);
            string base64buff = Convert.ToBase64String(jpgbuff);
            System.IO.File.WriteAllText(output,base64buff);   
        }
    }
}
