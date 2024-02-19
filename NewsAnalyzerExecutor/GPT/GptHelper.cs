namespace NewsAnalyzerExecutor.GPT
{
    /// <summary>
    ///     Хелперы для GPT
    /// </summary>
    public static class GptHelper
    {
        // TODO Вынести в параметры
        public const string RequestTemplate = @"
Вот список новостей: {0}
Скажи, как они повлияют на компании {1}
Ответ верни в таком-то формате";

        // TODO Мб тоже в параметры
        public static TimeSpan TradeOpenTime = new(10, 0, 0);

        // На 5 минут раньше, а то страшно, а там еще продать надо успеть
        public static TimeSpan TradeCloseTime = new(22, 55, 0);

        public const int PositiveNewsThreshold = 5;
        public const int NegativeNewsThreshold = -5;
    }
}
