using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoProject
{
    class Persons 
    {
        public  int PersonId { get; set; }
        public  string PersonFirstname { get; set; }
        public  string PersonLastname { get; set; }

        public Persons(int personId, string personFirstname, string personLastname)
        {
            this.PersonId = personId;
            this.PersonFirstname = personFirstname;
            this.PersonLastname = personLastname;
        }

        public Persons()
        {
        }
       
        public static List<Persons> personList = new List<Persons>();
       
        public void PersonAdd(int inputPersonID, string inputPersonFirstname, string inputPersonLastname)
        {
            Persons person = new Persons(inputPersonID, inputPersonFirstname, inputPersonLastname);
            personList.Add(person);
        }

        

      
    }
}
