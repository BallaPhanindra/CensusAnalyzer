using NUnit.Framework;
using CensusAnalyzer;
using CensusAnalyzer.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using CensusAnalyzer.DTO;

namespace CensusAnalyzer.CensusAnalyzerTest
{
        public class Tests
        {
            static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
            static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
            static string indianStateCensusFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCensusData.csv";
            static string wrongHeaderIndianCensusFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\WrongIndiaStateCensusData.csv";
            static string delimiterIndianCensusFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\IndianStateCesusDelimeter.csv";
            static string wrongIndianStateCensusFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\IndiaData.csv";
            static string wrongIndianStateCensusFileType = @"C:\Users\Ashokk\Desktop\BL\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianStateCensus.txt";
            static string indianStateCodeFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCodes.csv";
            static string wrongIndianStateCodeFileType = @"C:\Users\Ashokk\Desktop\BL\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCodes.txt";
            static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\DelimiterIndiaStateCodes.csv";
            static string wrongHeaderStateCodeFilePath = @"D:\BridgeLabz\CensusAnalyzer\CensusAnalyzer\CensusAnalyzer\CensusAnalyzerTest\WrongHeaderIndiaStateCodes.csv";

            CensusAnalyzer  censusAnalyser;
            Dictionary<string, CensusDTO> totalRecord;
            Dictionary<string, CensusDTO> stateRecord;

            [SetUp]
            public void Setup()
            {
                censusAnalyser = new CensusAnalyzer();
                totalRecord = new Dictionary<string, CensusDTO>();
                stateRecord = new Dictionary<string, CensusDTO>();
            }
            
            [Test]
            public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
            {
                totalRecord = censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
                Assert.AreEqual(5, totalRecord.Count);
            }
          
            [Test]
            public void GivenIndianCodeFilePath_WhenReaded_ShouldReturnStateCodeCount()
            {
                stateRecord = censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
                Assert.AreEqual(37, stateRecord.Count);
            }
         
            [Test]
            public void GivenWrongIndianCensusCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
            {
                var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            }
    
            [Test]
            public void GivenWrongIndianStateCodeFilePath_WhenRead_ShouldReturn_FILE_NOT_FOUND()
            {
                var stateException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
            }
            
            [Test]
            public void GivenWrongIndianStateCensusFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
            {
                var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            }
         
            [Test]
            public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnINVALID_FILE_TYPE()
            {
                var stateCodeException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INVALID_FILE_TYPE, stateCodeException.eType);
            }
          
            [Test]
            public void GivenWrongIndianCensusDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
            {
                var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            }
          
            [Test]
            public void GivenWrongIndianStateCodeDelimiter_WhenReaded_ShouldReturnINCORRECT_DELIMITER()
            {
                var stateCodeException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_DELIMITER, stateCodeException.eType);
            }
         
            [Test]
            public void GivenWrongIndianCensusDataFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
            {
                var censusException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
                Assert.AreEqual(CensusAnalyzerException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            }
            [Test]
            public void GivenWrongIndianStateCodeFilePath_WhenReaded_ShouldReturnINCORRECT_HEADER()
        {
            var stateCodeException = Assert.Throws<CensusAnalyzerException>(() => censusAnalyser.LoadCensusData(CensusAnalyzer.Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(GetINCORRECT_HEADER(), stateCodeException.eType);
        }

        private static CensusAnalyzerException.ExceptionType GetINCORRECT_HEADER()
        {
            return CensusAnalyzerException.ExceptionType.INCORRECT_HEADER;
        }
    }

}
