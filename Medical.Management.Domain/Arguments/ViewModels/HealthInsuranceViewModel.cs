﻿using Medical.Management.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Management.Domain.Arguments.ViewModels
{
    public class HealthInsuranceViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static HealthInsuranceViewModel FromEntity(HealthInsurance entity)
        {
            return new HealthInsuranceViewModel { Id = entity.Id, Name = entity.Name };
        }
    }
}
