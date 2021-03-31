using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.Utils
{
    public class TodoAppMapper : Profile
    {
        public TodoAppMapper() 
        {

            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<User, GetUserModel>();

            CreateMap<CreateUserDetailsModel, UserDetail>();
            CreateMap<UpdateUserDetailsModel, UserDetail>();
            CreateMap<UserDetail, GetUserDetailsModel>();

            CreateMap<CreateAddressDetailModel, AddressDetail>();
            CreateMap<UpdateAddressDetailModel, AddressDetail>();
            CreateMap<AddressDetail, GetAddressDetailModel>();

            CreateMap<CreateContactDetailModel, ContactDetail>();
            CreateMap<UpdateContactDetailModel, ContactDetail>();
            CreateMap<ContactDetail, GetContactDetailModel>();

            CreateMap<CreateCountryModel, Country>();
            CreateMap<UpdateCountryModel, Country>();
            CreateMap<Country, GetCountryModel>();
        }
    }
}
