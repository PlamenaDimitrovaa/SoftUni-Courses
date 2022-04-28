using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count();

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var currStock = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (!Portfolio.Contains(Portfolio.FirstOrDefault(s => s.CompanyName == companyName)))
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < currStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                Portfolio.Remove(currStock);
                MoneyToInvest += sellPrice;
                return $"{currStock.CompanyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine($"{stock}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
