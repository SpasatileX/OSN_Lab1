using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace Lab1;
class Program
{
    static void Main(string[] args)
    {
        string dataPath = "../../../data.csv";

        var mlContext = new MLContext();

        var data = mlContext.Data.LoadFromTextFile<DiseaseData>(
            dataPath,
            hasHeader: true,
            separatorChar: ',');

        var dataSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
        var trainingData = dataSplit.TrainSet;
        var testData = dataSplit.TestSet;

        var pipeline = mlContext.Transforms.Concatenate("Features",
                nameof(DiseaseData.Age),
                nameof(DiseaseData.NumberOfSexualPartners),
                nameof(DiseaseData.FirstSexualIntercourse),
                nameof(DiseaseData.NumOfPregnancies),
                nameof(DiseaseData.Smokes),
                nameof(DiseaseData.SmokesYears),
                nameof(DiseaseData.SmokesPacksPerYear),
                nameof(DiseaseData.HormonalContraceptives),
                nameof(DiseaseData.HormonalContraceptivesYears),
                nameof(DiseaseData.IUD),
                nameof(DiseaseData.IUDYears))
            .Append(mlContext.Transforms.ReplaceMissingValues("Features", replacementMode: MissingValueReplacingEstimator.ReplacementMode.Mean))
            .Append(mlContext.Transforms.NormalizeMinMax("Features"))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(new Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer.Options
            {
                LabelColumnName = "Label",
                FeatureColumnName = "Features"
            }));

        var model = pipeline.Fit(trainingData);

        var predictions = model.Transform(testData);
        var metrics = mlContext.BinaryClassification.Evaluate(predictions, labelColumnName: "Label");

        Console.WriteLine($"Accuracy: {metrics.Accuracy}");
        Console.WriteLine($"F1 Score: {metrics.F1Score}");
        Console.WriteLine($"AUC: {metrics.AreaUnderRocCurve}");

        string modelPath = "output.zip";
        mlContext.Model.Save(model, trainingData.Schema, modelPath);
        Console.WriteLine($"Модель збережено у {modelPath}");
    }
}

