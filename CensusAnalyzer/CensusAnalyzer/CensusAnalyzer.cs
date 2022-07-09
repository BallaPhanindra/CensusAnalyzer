using CensusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyzer
{
    internal class CensusAnalyzer
    {
        public enum Country
        {
            INDIA
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath,string dataHeaders)
        {
            dataMap = new CSVAdaptorFactory().LoadCsvData(country,csvFilePath,dataHeaders);
            return dataMap;
        }
    }
}
