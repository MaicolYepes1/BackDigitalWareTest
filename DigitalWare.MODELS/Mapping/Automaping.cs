using AutoMapper;
using DigitalWare.MODELS.Entities;
using DigitalWare.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.MODELS.Mapping
{
    public class Automaping : Profile
    {
        public Automaping()
        {
            CreateMap<ClienteEntitie, ClienteModel>().ReverseMap();
            CreateMap<ProductoEntitie, ProductoModel>().ReverseMap();
        }
    }
}
