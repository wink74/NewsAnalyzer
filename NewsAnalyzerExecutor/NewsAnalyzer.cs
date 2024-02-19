using NewsAnalyzerExecutor.GPT;
using NewsAnalyzerExecutor.TinkoffApi;

namespace NewsAnalyzerExecutor
{
    public class NewsAnalyzer
    {
        /// <summary>
        ///     Основной метод для анализа новостей, будет какая-то отдельная штука которая будет вызывать его каждые 30 минут
        /// </summary>
        public async Task Execute()
        {
            // TODO Получить дату последнего запуска
            // Если прошло больше 40 минут, то что-то не так
            var lastStartDate = DateTime.Now.AddMinutes(-30);

            var currentDate = DateTime.Now;

            // Получить новости с даты последнего запуска, либо за последние 30 минут
            var news = await this.GetNews(lastStartDate, DateTime.Now);

            // Хз откуда брать, по идее должна быть возможность менять список, надо в параметры куда-то запихать,
            // пока просто пустой список компаний
            var companyNames = new List<string>();

            // Получаем ответ от ChatGPT
            var gptResponse = GptApiWorker.GetGptResponse(news, companyNames);

            // Что-то сделать, если ничего не вернуло
            if (gptResponse?.Predictions is null)
            {
                // Какие-то действия

                return;
            }

            foreach (var prediction in gptResponse.Predictions)
            {
                // Хорошая приятная новость, хорошо повлияет на акции
                if (prediction.Rating > GptHelper.PositiveNewsThreshold)
                {
                    // Новость до открытия биржи - закидываем запись в БД с именем компании
                    // и временем, когда надо купить
                    if (currentDate.TimeOfDay < GptHelper.TradeOpenTime
                        || currentDate.TimeOfDay >= GptHelper.TradeCloseTime)
                    {
                        // Время покупки - следующее открытие биржи
                        var plannedBuyingTime = currentDate.TimeOfDay >= GptHelper.TradeCloseTime
                            ? currentDate.AddDays(1).Date.Add(GptHelper.TradeOpenTime)
                            : currentDate.Date.Add(GptHelper.TradeOpenTime);
                        
                        // Записываем время покупки + prediction.CompanyName в БД + число купленных акций
                        // TODO БД

                        // Время продажи - перед закрытием биржи
                        var plannedSellTime = plannedBuyingTime.Date.Add(GptHelper.TradeCloseTime);

                        // Записываем время продажи + prediction.CompanyName в БД + число акций для продажи
                        // TODO БД
                    }
                    // Новость после открытия биржи
                    else
                    {
                        // Как-то определяем, сколько купить акций
                        // Мб что-то типа такого (готов потратить 10к, на основании этого считаем кол-во акций)
                        var readyToSpend = 10000;
                        var stockBuyCount = (int)(readyToSpend / await StocksManager.GetStockPriceAsync(prediction.CompanyName));

                        // Покупаем прямо щас
                        // Если вдруг не удалось, то что-то тут делаем
                        if (!await StocksManager.BuyAsync(prediction.CompanyName, stockBuyCount))
                        {
                            // ?????
                            return;
                        }

                        var plannedSellTime = currentDate.AddDays(1).Date.Add(GptHelper.TradeCloseTime);

                        // Записываем время продажи + prediction.CompanyName в БД + число акций для продажи (stockBuyCount)
                        // TODO БД
                    }
                }
                // Грустная новость, плохо повлияет на акции
                else if (prediction.Rating < GptHelper.NegativeNewsThreshold)
                {
                    // НИЧО НЕ ПОНЯЛ ЧТО ДЕЛАТЬ ТУТ
                }
            }
        }

        /// <summary>
        ///     Метод получения новостей (пока хз - ссылки или текст или еще что-то)
        /// </summary>
        /// <param name="dateStart">Дата, начиная с которой брать новости</param>
        /// <param name="dateEnd">Дата, заканчивая которой брать новости</param>
        /// <returns>Список новостей</returns>
        private async Task<List<string>> GetNews(DateTime dateStart, DateTime dateEnd)
        {
            // TODO Как-то откуда-то взять новости
            return new List<string>();
        }
    }
}
