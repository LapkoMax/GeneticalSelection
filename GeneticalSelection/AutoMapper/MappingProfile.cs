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
            CreateMap<Phylum, PhylumDto>();
            CreateMap<Subphylum, SubphylumDto>();
            CreateMap<Class, ClassDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Family, FamilyDto>();
            CreateMap<Genus, GenusDto>();
            CreateMap<Species, SpeciesDto>();
            CreateMap<KingdomForCreationDto, Kingdom>();
            CreateMap<PhylumForCreationDto, Phylum>();
            CreateMap<SubphylumForCreationDto, Subphylum>();
            CreateMap<ClassForCreationDto, Class>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<FamilyForCreationDto, Family>();
            CreateMap<GenusForCreationDto, Genus>();
            CreateMap<SpeciesForCreationDto, Species>();
        }
    }
}
