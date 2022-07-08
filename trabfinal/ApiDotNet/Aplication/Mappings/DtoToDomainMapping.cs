using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDotNet.Domain.Entities;
using Aplication.DTOs;
using AutoMapper;

namespace Aplication.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
            
        }
    }
}