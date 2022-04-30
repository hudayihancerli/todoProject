using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoProject
{
    class Card
    {
        static int _CardId = 0;
        public enum cardSizes
        {
            xs,s,m,l,xl
        }

        public int CardId { get; set; }
        public string CardTitle { get; set; }
        public string CardContent { get; set; }
        public int CardPersons { get; set; }
        public cardSizes CardSize { get; set; }


        Card(int inputCarId, string inputCardTitle, string inputCardContent, int inputCardPersons, cardSizes inputCardSize)
        {
            
            this.CardId = inputCarId;
            this.CardTitle = inputCardTitle;
            this.CardContent = inputCardContent;
            this.CardPersons = inputCardPersons;
            this.CardSize = inputCardSize;
        }
        public Card() 
        {
        }
      
        Persons person = new Persons();
        Board board = new Board();


        #region BoardAddCard

        public void BoardAddCard()
        {
            //id
            _CardId++;

            //title
            Console.Write("title : ");
            string inputCardTitle = Console.ReadLine();

            //content
            Console.Write("Content : ");
            string inputCardContent = Console.ReadLine();

            //person
            Console.WriteLine("Person : ");
            int inputCardPersons;

            //personList öğeleri
            foreach (Persons p in Persons.personList)
            {
                Console.Write($"{p.PersonId} - {p.PersonFirstname} {p.PersonLastname} ||| ");
            }
            
            //personİd seç
            int selectedPerson = int.Parse(Console.ReadLine());

            //seçili personid personlistesinde var mı ? seciliİd kullan : programdan çık
            if(selectedPerson < Persons.personList.Count)
            {
                inputCardPersons = selectedPerson;
            }
            else
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                Environment.Exit(0);
                inputCardPersons = 1;
            }
            
            //Cardsize
            Console.WriteLine("Card Size : ");

            cardSizes inputCardSize;

            int sizeCount = 0;
            //cardsizes listele
            foreach (var size in Enum.GetNames(typeof(cardSizes)))
            {
                sizeCount++;
                Console.Write($"({sizeCount}) {size} ||| ");
            }
            //cardsizes id seç
            int selectedSize = int.Parse(Console.ReadLine());

            //seçili id'ye göre cardsisezden veri ata
            switch (selectedSize)
            {
                case 1: inputCardSize = cardSizes.xs; break;
                case 2: inputCardSize = cardSizes.s; break;
                case 3: inputCardSize = cardSizes.m; break;
                case 4: inputCardSize = cardSizes.l; break;
                case 5: inputCardSize = cardSizes.xl; break;
                default:inputCardSize = cardSizes.xs;break;
            }

            //card adında nesne oluşturup değerleri bu nesneye atar
            Card card = new Card(_CardId, inputCardTitle, inputCardContent, inputCardPersons, inputCardSize); 

            //todo listesine card nesnesini ekler
            Board.Todo.Add(card);
        }

        #endregion


        #region BoardAddCard

        public void BoardAddCard(string inputCardTitle, string inputCardContent, int inputCardPersons, cardSizes inputCardSize)
        {
            //id
            _CardId++;

            //card adında nesne oluşturup değerleri bu nesneye atar
            Card card = new Card(_CardId, inputCardTitle, inputCardContent, inputCardPersons, inputCardSize);

            //todo listesine card nesnesini ekler
            Board.Todo.Add(card);
        }

        #endregion


        public void BoardDeleteCard()
        {
            Console.Write("Lütfen silmek istediiniz kartın baslığını giriniz : ");
            string deleteTitle = Console.ReadLine(); 

            //silinecek kartın hangi line'da olduğunu bulur ve siler.
            if (Board.Todo.Where( X => X.CardTitle == deleteTitle).Count() == 1)
            {
                //listenin ilk cardTitle'si silenecek kartın title'sine eşitse sil.
                Board.Todo.Remove(Board.Todo.Where(X => X.CardTitle == deleteTitle).First());
                Console.WriteLine(" Todo Line'dan kart silindi.");
            }
            else if(Board.InProgress.Where(X => X.CardTitle == deleteTitle).Count() == 1)
            {
                Board.InProgress.Remove(Board.InProgress.Where(X => X.CardTitle == deleteTitle).First());
                Console.WriteLine(" InProgress Line'dan kart silindi.");
            }
            else if (Board.Done.Where(X => X.CardTitle == deleteTitle).Count() == 1)
            {
                Board.Done.Remove(Board.Done.Where(X => X.CardTitle == deleteTitle).First());
                Console.WriteLine(" Done Line'dan kart silindi.");
            }
            else
            {
                Console.WriteLine("Kart Bulunamadı.");
            }
        }

        //overloading
        public void BoardDeleteCard(List<Card> cards,string deleteTitle)
        {
         
            if (cards.Where(X => X.CardTitle == deleteTitle).Count() == 1)
            {
                cards.Remove(cards.Where(X => X.CardTitle == deleteTitle).First());
                Console.WriteLine(" Todo Line'dan kart silindi.");
            }
            else
            {
                Console.WriteLine("Kart Bulunamadı.");
            }
        }

        
        #region CarryCard

        public void CarryCard()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız : ");

            string cardTitle = Console.ReadLine();

            //taşınmak istenen kartın nerede olduğunu bulur.
            if (Board.Todo.Where(x => x.CardTitle == cardTitle).Count() == 1)
            {

                carry(Board.Todo, cardTitle); //kartı taşır
                BoardDeleteCard(Board.Todo, cardTitle);//kartın eski bölgesindegi verileri siler
                Console.WriteLine("Kart taşındı.");
            }
            else if(Board.InProgress.Where(x => x.CardTitle == cardTitle).Count() == 1)
            {
                carry(Board.InProgress, cardTitle);
                Console.WriteLine("Kart taşındı.");
                BoardDeleteCard(Board.InProgress, cardTitle);
            }
            else if(Board.Done.Where(x => x.CardTitle == cardTitle).Count() == 1)
            {
                carry(Board.Done, cardTitle);
                Console.WriteLine("Kart taşındı.");
                BoardDeleteCard(Board.Done, cardTitle);
            }
            else
            {
                Console.WriteLine("Kart bulunamadı.");
            }

            
        }

        #endregion


        void carry(List<Card> Line,string inputCardTitle)
        {
            Console.WriteLine("Taşımak istediğiniz line'i seçiniz");
            Console.Write("(1) Todo - ");
            Console.Write("(2) In Progress - ");
            Console.Write("(3) Done");
            int selectedLine = int.Parse(Console.ReadLine());

            var newCard = new Card();


            //taşınacak olan kartın verilerini newCard'a atar
            newCard.CardId = Line.Where(x => x.CardTitle == inputCardTitle).FirstOrDefault().CardId;
            newCard.CardTitle = Line.Where(x => x.CardTitle == inputCardTitle).FirstOrDefault().CardTitle;
            newCard.CardContent = Line.Where(x => x.CardTitle == inputCardTitle).FirstOrDefault().CardContent;
            newCard.CardPersons = Line.Where(x => x.CardTitle == inputCardTitle).FirstOrDefault().CardPersons;
            newCard.CardSize = Line.Where(x => x.CardTitle == inputCardTitle).FirstOrDefault().CardSize;

            //newCarddaki verileri taşınacak line'ya atar.
            switch (selectedLine)
            {
                case 1: Board.Todo.Add(newCard); break;
                case 2: Board.InProgress.Add(newCard); break;
                case 3: Board.Done.Add(newCard); break;
                default:Console.WriteLine("Hatalı seçim."); break;
            }
            
        }

    }
}
