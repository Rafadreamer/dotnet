using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using Aplication.DTOs;
using Aplication.DTOs.Validations;
using Aplication.Services.Interfaces;
using AutoMapper;
using Domain.Repositories;

namespace Aplication.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if(purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("informe o obj compra");
            
            var validate = new PurchaseDTOvalidator().Validate(purchaseDTO);
            if(!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("valide os campos", validate);
            
            var productId = await _productRepository.GetIdByCoderpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIDByDocumentAsync(purchaseDTO.Document);

            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);

        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if(purchase == null)
                return  ResultService.Fail<PurchaseDetailDTO>("compra nao encontrada");

            return ResultService.Ok(_mapper.Map<PurchaseDetailDTO>(purchase));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(id);
            if(purchase == null)
                return  ResultService.Fail("compra nao encontrada");
            
            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.Ok($" compra de id:{id} deletada"); 
            
        }
    }
}