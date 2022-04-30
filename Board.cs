using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoProject
{
    class Board
    {
        public static List<Card> Todo = new List<Card>();
        public static List<Card> InProgress= new List<Card>();
        public static List<Card> Done = new List<Card>();


        public void BoardList()
        {  
            
            Console.WriteLine(" TODO Line");
            Console.WriteLine(" ************Hüdayi************");
            if (Todo.Count > 0 )
            {
                foreach (Card t in Todo)
                {
                    Console.WriteLine($"Başlık      : {t.CardTitle}");
                    Console.WriteLine($"İçerik      : {t.CardContent}");
                    Console.WriteLine($"Atanan Kişi : {t.CardPersons}");
                    Console.WriteLine($"Büyüklük    : {t.CardSize}");
                    Console.WriteLine(" - ");
                }
            }
            else
            {
                Console.WriteLine("\n ~ BOŞ ~ \n");
            }
          
           

            Console.WriteLine(" IN PROGRESS Line");
            Console.WriteLine(" ************************");

            if (InProgress.Count > 0)
            {
                foreach (Card I in InProgress)
                {
                    Console.WriteLine($"Başlık      : {I.CardTitle}");
                    Console.WriteLine($"İçerik      : {I.CardContent}");
                    Console.WriteLine($"Atanan Kişi : {I.CardPersons}");
                    Console.WriteLine($"Büyüklük    : {I.CardSize}");
                    Console.WriteLine(" - ");
                }
            }
            else
            {
                Console.WriteLine("\n ~ BOŞ ~ \n");
            }


            Console.WriteLine("  DONE Lines");
            Console.WriteLine(" ************************");
            if (Done.Count > 0)
            {
                foreach (Card d in Done)
                {
                    Console.WriteLine($"Başlık      : {d.CardTitle}");
                    Console.WriteLine($"İçerik      : {d.CardContent}");
                    Console.WriteLine($"Atanan Kişi : {d.CardPersons}");
                    Console.WriteLine($"Büyüklük    : {d.CardSize}");
                    Console.WriteLine(" - ");
                }
            }
            else
            {
                Console.WriteLine("\n ~ BOŞ ~ \n");
            }
        }
    }
}
