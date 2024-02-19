using System.Text.Json;

namespace NewsAnalyzerExecutor.GPT
{
    /// <summary>
    ///     Класс для работы с ChatGPT, пока статик, наверное нужен будет через DI
    /// </summary>
    public static class GptApiWorker
    {
        /// <summary>
        ///     Получить ответ от GPT
        /// </summary>
        /// <param name="news">Список новостей</param>
        /// <param name="companyNames">Наименования компаний</param>
        /// <returns>По идее вернет json, который надо парсить здесь и возвращать готовые классы</returns>
        public static GptResponse? GetGptResponse(List<string> news, List<string> companyNames)
        {
            var request = string.Format(GptHelper.RequestTemplate,
                string.Join(Environment.NewLine, news),
                string.Join(Environment.NewLine, companyNames));

            // Кидаем запрос и получаем ответ от ChatGPT
            var response = "{}";

            return JsonSerializer.Deserialize<GptResponse>(response);
        }
    }
}
