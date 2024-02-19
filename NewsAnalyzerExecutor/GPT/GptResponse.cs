namespace NewsAnalyzerExecutor.GPT
{
    // Классы для десериализации json

    public class GptResponse
    {
        public Prediction[] Predictions { get; set; }
    }

    public class Prediction
    {
        public string CompanyName { get; set; }
        public int Rating { get; set; }
    }
}
