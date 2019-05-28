using System;
using System.IO;
using System.Json;

namespace myAppNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                readJsonFile rj = new   readJsonFile();
                rj.readFile("config.json");
                string myval = rj.JsonValue("config.json","Created");

                Console.WriteLine("Hello - " + myval);
                Console.WriteLine("the time now is:" + System.DateTime.Now);
                
                mytest test = new mytest();
                test.ConvertJpgtoBase64("photoinput.jpg","base64.bin");

                Console.WriteLine("done");
                // System.Diagnostics.Process.Start( "calculator");                
                
                string yourinput =Console.ReadLine();
                Console.WriteLine(value: "hello: " + yourinput);
            }
            catch(Exception error)
            {
                Console.Write(error.Message);
            }
        }
    }

    //test conversion from base64
    public class mytest
    {
        public void ConvertJpgtoBase64(string input,string output)
        {
            byte[] jpgbuff = System.IO.File.ReadAllBytes(input);
            string base64buff = Convert.ToBase64String(jpgbuff);
            System.IO.File.WriteAllText(output,base64buff);   
        }
    }

    //test read json
    public class readJsonFile
    {
        public void readFile(string fileName)
        {
            var stream = File.OpenText(fileName); 
            //Read the file              
            string st = stream.ReadToEnd();                           
            var jsonArray = JsonArray.Parse(st);              
            foreach (var item in jsonArray)              
            {                                   
                JsonObject ob = new JsonObject(item);                   
                foreach (var t in ob.Values)                  
                {                       
                    JsonObject oo = new JsonObject(t);                       
                    foreach (var x in oo)                      
                    {                          
                        Console.Write(x.Key + " : " + x.Value + "\n");                      
                    }                  
                }            
            }
        }

        public string JsonValue(string fileName,string key)
        {
            var stream = File.OpenText(fileName);    
            //Read the file              
            string st = stream.ReadToEnd();                           
            var jsonArray = JsonArray.Parse(st);        
            foreach (var item in jsonArray)              
            {                                   
                JsonObject ob = new JsonObject(item);                   
                foreach (var t in ob.Values)                  
                {                       
                    JsonObject oo = new JsonObject(t);                       
                    foreach (var x in oo)                      
                    {  
                        if(x.Key == key)                        
                          return x.Value.ToString();                        
                    }                  
                }            
            }    
            return "";                    
        }
    }
}
