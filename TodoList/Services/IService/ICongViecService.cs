using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services.IService
{
    public interface ICongViecService
    {
        Task<IEnumerable<CongViec>> GetAllCongViecs();
        Task<CongViec> GetOneCongViec(int id);
        Task<CongViec> CreateCongViec(string name);
        void AddCongViec(CongViec congViec);
        void UpdateCongViec(CongViec congViec);
        void DeleteCongViec(CongViec congViec);
        Task Save();
    }
}