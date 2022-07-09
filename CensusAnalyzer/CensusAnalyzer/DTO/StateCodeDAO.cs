﻿using System;

namespace CensusAnalyzer.DTO
{
    public class StateCodeDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            serialNumber = Convert.ToInt32(v1);
            stateName = v2;
            tin = Convert.ToInt32(v3);
            stateCode = v4;
        }
    }
}