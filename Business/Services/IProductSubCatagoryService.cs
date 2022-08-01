﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductSubCatagoryService
    {
        public Task Create(ProductSubCatagory productSubCatagory);
        public Task CreateMultiple(List<ProductSubCatagory> productSubCatagories);
    }
}
