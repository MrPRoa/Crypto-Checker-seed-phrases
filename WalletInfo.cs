namespace CryptoChecker
{
    public class TokenInfo
    {
        public string Symbol { get; set; }
        public double Balance { get; set; }
        public double UsdValue { get; set; }
    }

    public class WalletInfo
    {
        public string Phrase { get; set; }

        public string BtcAddress { get; set; }

        public string EthAddress { get; set; }

        public string BnbAddress { get; set; }

        // Новые сети с тем же адресом что и ETH
        public double PolygonBalance { get; set; }
        public double AvalancheBalance { get; set; }
        public double PolkadotBalance { get; set; }
        public double ArbitrumBalance { get; set; }

        public string LtcAddress { get; set; }
        public double LtcBalance { get; set; }

        public string SolAddress { get; set; }
        public double SolBalance { get; set; }

        // Токены ERC20/BEP20
        public double BnbUsdtBalance { get; set; }
        public double EthUsdtBalance { get; set; }
        public double PolygonUsdtBalance { get; set; }
        public double ArbitrumUsdtBalance { get; set; }
        public double TrxUsdtBalance { get; set; }
        
        // Общий баланс в USD
        public double TotalBalanceUsd { get; set; }

        public bool HasBalance
        {
            get
            {
                // Округляем значения до 8 знаков после запятой для избежания ошибок с плавающей точкой
                const double epsilon = 0.000000001; // 1e-9
                
                return 
                    Math.Abs(BtcBalance) > epsilon || 
                    Math.Abs(EthBalance) > epsilon || 
                    Math.Abs(BnbBalance) > epsilon || 
                    Math.Abs(LtcBalance) > epsilon ||
                    Math.Abs(SolBalance) > epsilon ||
                    Math.Abs(PolygonBalance) > epsilon || 
                    Math.Abs(AvalancheBalance) > epsilon || 
                    Math.Abs(PolkadotBalance) > epsilon || 
                    Math.Abs(ArbitrumBalance) > epsilon;
            }
        }

        public double BtcBalance { get; set; }

        public double EthBalance { get; set; }

        public double BnbBalance { get; set; }

        // Добавьте другие криптовалюты здесь при необходимости

        public List<TokenInfo> EthTokens { get; set; } = new List<TokenInfo>();
        public List<TokenInfo> BnbTokens { get; set; } = new List<TokenInfo>();
        public double TotalTokenValueUsd { get; set; }

        public string XrpAddress { get; set; }

        public string TrxAddress { get; set; }

        public string MaticAddress { get; set; }
        public string AvaxAddress { get; set; }
        public string ArbitrumAddress { get; set; }

        // Добавляем конфигурации сетей
        public static readonly Dictionary<string, (string rpc, int chainId)> Networks = new()
        {
            ["ETH"] = ("https://eth.meowrpc.com", 1),
            ["BSC"] = ("https://bsc-dataseed1.binance.org", 56),
            ["POLYGON"] = ("https://polygon-rpc.com", 137),
            ["ARBITRUM"] = ("https://arb1.arbitrum.io/rpc", 42161),
            ["AVALANCHE"] = ("https://api.avax.network/ext/bc/C/rpc", 43114)
        };

        // Добавляем конфигурации газа
        public static readonly Dictionary<string, (decimal multiplier, int gasLimit, decimal minGasGwei)> GasConfigs = new()
        {
            ["ETH"] = (1.1m, 21000, 12),
            ["BSC"] = (1.05m, 21000, 3),
            ["POLYGON"] = (1.3m, 21000, 50),
            ["ARBITRUM"] = (1.2m, 400000, 0.1m),
            ["AVALANCHE"] = (1.1m, 21000, 25)
        };
    }
}
