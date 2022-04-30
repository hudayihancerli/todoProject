using System;

namespace todoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            Persons persons = new Persons();
            Board board = new Board();

            /*person add*/
            persons.PersonAdd(1,"Mahmut Hüdayi", "Hançerli");
            persons.PersonAdd(2,"Bilge", "Kağan");
            persons.PersonAdd(3,"Tekin", "Yenilmez");
            persons.PersonAdd(4,"Timur", "Demir");
            persons.PersonAdd(5,"Kürşad", "Öncü");

            card.BoardAddCard("Başlık","İçerik",1,Card.cardSizes.xl);
            card.BoardAddCard("Alıncakalar","-1kğ elma - yumurta - 2 ekmek",1,Card.cardSizes.xl);
            card.BoardAddCard("Yapılacaklar",".netcore patkiasını bitir",1,Card.cardSizes.xl);

            try
            {
                do
                {
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("(1) Board Listelemek");
                    Console.WriteLine("(2) Board'a Kart Eklemek");
                    Console.WriteLine("(3) Board'dan Kart Silmek");
                    Console.WriteLine("(4) Kart Taşımak");
                    Console.Write("Lütfen yapmak istediğiniz işlemi seçiniz : ");

                    int selected = Convert.ToInt32(Console.ReadLine());

                    switch (selected)
                    {
                        case 1: board.BoardList(); break;
                        case 2: card.BoardAddCard(); break;
                        case 3: card.BoardDeleteCard(); break;
                        case 4: card.CarryCard(); break;
                        default: Console.WriteLine("Lütfen belirtilen rakamlardan birisini giriniz."); break;
                    }

                } while (true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata : " + e.Message);
            }
        }
    }
}
