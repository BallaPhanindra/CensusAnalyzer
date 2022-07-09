using CensusAnalyzer.DTO;
using CensusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensusAnalyzer
{
    internal class CSVAdaptorFactory
    {

        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyzer.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyzer.Country.INDIA):
                    return new IndianCensusAdaptor().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyzerException("No such Country", CensusAnalyzerException.ExceptionType.NO_SUCH_COUNTRY);
            }

        }
    }
}