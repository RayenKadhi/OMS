using OMS.Interfaces;

namespace OMS.Data
{
    public class RevenueDataService
    {
        private readonly IDapperService _dapperService;
        public RevenueDataService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
    }
}
