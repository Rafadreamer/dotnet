using System;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using Aplication.DTOs;
using Aplication.DTOs.Validations;
using Aplication.Services.Interfaces;
using AutoMapper;

namespace Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {   
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if(productDTO == null)
                return ResultService.Fail<ProductDTO>("informe os valores do obj.");
            
            var result = new ProductDTOvalidator().Validate(productDTO);
            if(!result.IsValid)
                return ResultService.RequestError<ProductDTO>("valide os campos porra", result);
            
            var product = _mapper.Map<Product>(productDTO);
            
            var data = await _productRepository.CreateAsync(product);
                return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));

        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
                return  ResultService.Fail<ProductDTO>("pessoa nao encontrada");

            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
                return  ResultService.Fail<ProductDTO>("produto nao encontrada");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"produto de id:{id} deletada");
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if(productDTO == null)
                return ResultService.Fail("informe os dados para atualizar");

            var validation = new ProductDTOvalidator().Validate(productDTO);
            if(!validation.IsValid)
                return ResultService.RequestError("valide os campos", validation);
            
            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if(product == null)
                return ResultService.Fail("Produto nao encontrado");
            
            product = _mapper.Map<ProductDTO, Product>(productDTO, product);
            await _productRepository.EditAsync(product);
                return ResultService.Ok("produto editado com sucesso");
        }
    }
}