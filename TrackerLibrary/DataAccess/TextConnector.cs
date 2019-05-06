using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PersonsFile = "PersonModels.csv";

        // *TODO: Wire up the CreatePrize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizesFile.GetFullPath().LoadFile().ConvertToPrizeModel();
            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            prizes.Add(model);
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        // Wire up the CreatePrize for text files
        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = PersonsFile.GetFullPath().LoadFile().ConvertToPersonModel();
            int currentId = 1;
            if(persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            persons.Add(model);
            persons.SaveToPersonFile(PersonsFile);

            return model;
        }

        public List<PersonModel> GetPerson_ALL()
        {
            return PersonsFile.GetFullPath().LoadFile().ConvertToPersonModel();
        }
    }
}