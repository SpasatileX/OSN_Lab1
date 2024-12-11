using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1;

class DiseaseData
{
    [LoadColumn(0)] public float Age;
    [LoadColumn(1)] public float NumberOfSexualPartners;
    [LoadColumn(2)] public float FirstSexualIntercourse;
    [LoadColumn(3)] public float NumOfPregnancies;
    [LoadColumn(4)] public float Smokes;
    [LoadColumn(5)] public float SmokesYears;
    [LoadColumn(6)] public float SmokesPacksPerYear;
    [LoadColumn(7)] public float HormonalContraceptives;
    [LoadColumn(8)] public float HormonalContraceptivesYears;
    [LoadColumn(9)] public float IUD;
    [LoadColumn(10)] public float IUDYears;
    [LoadColumn(11)] public float STDs;
    [LoadColumn(12)] public float STDsNumber;
    [LoadColumn(13)] public float STDsCondylomatosis;
    [LoadColumn(14)] public float STDscervicalCondylomatosis;
    [LoadColumn(15)] public float STDsvaginalCondylomatosis;
    [LoadColumn(16)] public float STDsvulvoPerinealCondylomatosis;
    [LoadColumn(17)] public float STDssyphilis;
    [LoadColumn(18)] public float STDspelvicInflammatoryDisease;
    [LoadColumn(19)] public float STDsgenitalHerpes;
    [LoadColumn(20)] public float STDsmolluscumContagiosum;
    [LoadColumn(21)] public float STDsAIDS;
    [LoadColumn(22)] public float STDsHIV;
    [LoadColumn(23)] public float STDsHepatitisB;
    [LoadColumn(24)] public float STDsHPV;
    [LoadColumn(25)] public float STDsNumberOfDiagnosis;
    [LoadColumn(26)] public float STDsTimeSinceFirstDiagnosis;
    [LoadColumn(27)] public float STDsTimeSinceLastDiagnosis;
    [LoadColumn(28)] public float DxCancer;
    [LoadColumn(29)] public float DxCIN;
    [LoadColumn(30)] public float DxHPV;
    [LoadColumn(31)] public bool Label;
}
