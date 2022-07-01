using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextExtensions;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        /// TODO: Make the CreatePrize method actually save to the text file
        /// <summary>
        /// Saves a new prize to the text file
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information, including the unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load csv file and convert to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find next available Id, set to one if the file has no records/does not exist
            int nextAvailableId = 1;

            if (prizes.Count > 0) 
            {
                nextAvailableId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            // Add Id to model and add model to List<PrizeModel>
            model.Id = nextAvailableId;
            prizes.Add(model);

            // Convert List<PrizeModel> back to csv and write to file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
