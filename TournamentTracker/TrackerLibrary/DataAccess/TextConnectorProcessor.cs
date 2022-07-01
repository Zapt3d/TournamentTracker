using System.Configuration;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextExtensions
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Concatenates filename and App.config filepath to a full file path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>
        /// full filepath as <c>string</c> to specified file
        /// </returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        /// <summary>
        /// Checks if specified file exists and loads the file content to a list
        /// </summary>
        /// <param name="file"></param>
        /// <returns>
        /// Exists: contents of the file in list<br></br>
        /// Does not exist: new empty list
        /// </returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Converts the text to List<PrizeModel>
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>
        /// <c>List<PrizeModel></c> that was converted from lines
        /// </returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> prizeModels = new();

            foreach(string line in lines)
            {
                string[] columns = line.Split(',');

                PrizeModel prizeModel = new()
                {
                    Id = int.Parse(columns[0]),
                    PlaceNumber = int.Parse(columns[1]),
                    PlaceName = columns[2],
                    PrizeAmount = decimal.Parse(columns[3]),
                    PrizePercentage = double.Parse(columns[4])
                };
                prizeModels.Add(prizeModel);
            }
            return prizeModels;
        }

        /// <summary>
        /// Saves changed prizemodels to the csv file
        /// </summary>
        /// <param name="models"></param>
        /// <param name="fileName"></param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new();

            foreach (PrizeModel model in models)
            {
                lines.Add($"{model.Id},{model.PlaceNumber},{model.PlaceName},{model.PrizeAmount},{model.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
