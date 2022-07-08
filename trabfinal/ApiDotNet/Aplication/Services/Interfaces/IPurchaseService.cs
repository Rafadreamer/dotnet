using System;
using Aplication.DTOs;

namespace Aplication.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task <ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
        Task <ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
        Task<ResultService> RemoveAsync(int id);

    }
}