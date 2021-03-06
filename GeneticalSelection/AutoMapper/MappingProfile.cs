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

            CreateMap<KingdomForUpdateDto, Kingdom>();
            CreateMap<PhylumForUpdateDto, Phylum>();
            CreateMap<SubphylumForUpdateDto, Subphylum>();
            CreateMap<ClassForUpdateDto, Class>();
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<FamilyForUpdateDto, Family>();
            CreateMap<GenusForUpdateDto, Genus>();
            CreateMap<SpeciesForUpdateDto, Species>();
        }
    }
}
