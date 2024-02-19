namespace NewsAnalyzerExecutor.TinkoffApi
{
    /// <summary>
    ///     Класс для покупки/продажи акций, вряд ли должен быть статик
    /// </summary>
    public static class StocksManager
    {
        /// <summary>
        ///     Купить акции
        /// </summary>
        /// <param name="companyName">Название компании</param>
        /// <param name="count">Кол-во акций или мб сумма, на которую купить акции/мб вообще не надо параметр</param>
        /// <returns>Успех/не успех (или возвращать кол-во купленных акций)</returns>
        public static async Task<bool> BuyAsync(string companyName, int count)
        {
            // TODO Мб брать общее кол-во доступных денег на счете и покупать акций на процент от них (добавить метод получения баланса)
            // TODO Какие-то логи для истории операций
            // TODO Мб еще не получится купить все акции и нужно возвращать кол-во акций, которые на самом деле получилось купить
            return true;
        }

        /// <summary>
        ///     Продать акции
        /// </summary>
        /// <param name="companyName">Название компании</param>
        /// <param name="count">Кол-во акций</param>
        /// <returns>Успех/не успех</returns>
        public static async Task<bool> SellAsync(string companyName, int count)
        {
            // TODO Какие-то логи для истории операций
            return true;
        }

        /// <summary>
        ///     Получить цену акции компании
        /// </summary>
        /// <param name="companyName">Компания</param>
        /// <returns>Цена акции</returns>
        public static async Task<double> GetStockPriceAsync(string companyName)
        {
            return 100.0;
        }
    }
}
