using AutoMapper;
using GeneticalSelection.Models.DataTransferObjects;
using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kingdom, KingdomDto>();
            CreateMap<KingdomForCreationDto, Kingdom>();
        }
    }
}
