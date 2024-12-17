﻿using ATMApplication.Application.Dto;
using ATMApplication.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplication.Application
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper() 
        {
            CreateMap<Account,AccountDto>().ReverseMap();
            CreateMap<Account, UserAccountDto>().ReverseMap();  
        }
    }
}
