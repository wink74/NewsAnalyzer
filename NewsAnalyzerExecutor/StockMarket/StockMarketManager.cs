using NewsAnalyzerExecutor.TinkoffApi;

namespace NewsAnalyzerExecutor.StockMarket
{
    /// <summary>
    ///     Действия при открытии/закрытии биржи, будет какая-то штука, которая будет вызывать методы при открытии/закрытии биржи
    /// </summary>
    public static class StockMarketManager
    {
        /// <summary>
        ///     Действия при открытии биржи
        /// </summary>
        public static async Task OnOpeningAsync()
        {
            // Читаем из БД какие акции нужно купить и покупаем
            var allPlanned = new List<PlannedStocks>();
            foreach (var planned in allPlanned)
            {
                await StocksManager.BuyAsync(planned.CompanyName, planned.Count);
            }
        }

        /// <summary>
        ///     Действия при закрытии биржи
        /// </summary>
        public static async Task OnClosingAsync()
        {
            // Читаем из БД какие акции нужно продать и продаем
            var allPlanned = new List<PlannedStocks>();
            foreach (var planned in allPlanned)
            {
                await StocksManager.SellAsync(planned.CompanyName, planned.Count);
            }
        }
    }
}
