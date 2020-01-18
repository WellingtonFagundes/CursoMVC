using AutoMapper;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.Domain;
using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Application.AutoMapper
{
    public class DomainToViewModel:Profile
    {
        public DomainToViewModel()
        {
            //Quando os sentidos forem iguais usar ReverseMap
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap(); ;
        }
    }
}
