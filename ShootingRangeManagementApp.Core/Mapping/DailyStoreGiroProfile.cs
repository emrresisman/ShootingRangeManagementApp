using AutoMapper;
using ShootingRangeManagementApp.Dtos;
using ShootingRangeManagementApp.Dtos.DailyStoreGiroDtos;
using ShootingRangeManagementApp.Dtos.StoreDtos;
using ShootingRangeManagementApp.Dtos.StorePartnerDtos;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.Mapping
{
    public class DailyStoreGiroProfile:Profile 
    {
        public DailyStoreGiroProfile()
        {
            //CreateMap<DailyStoreGiro, EditDailyStoreGiroDto>();
            //CreateMap<EditDailyStoreGiroDto, DailyStoreGiro>();

            CreateMap<Store, EditStoreDto>();
            CreateMap<EditStoreDto, Store>();

            CreateMap<StorePartner, CreateStorePartnerDto>();
            CreateMap<CreateStorePartnerDto, StorePartner>();

            CreateMap<StorePartner, EditStorePartnerDto>();
            CreateMap<EditStorePartnerDto, StorePartner>();

            CreateMap<DailyStoreGiro, EditDailyStoreGiroDto>();
            CreateMap<EditDailyStoreGiroDto, DailyStoreGiro>();
            
            CreateMap<Bills, EditDailyBillDto>();
            CreateMap<EditDailyBillDto, Bills>();
        }
    }
}
