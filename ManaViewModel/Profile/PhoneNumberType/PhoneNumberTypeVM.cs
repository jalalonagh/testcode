﻿using ManaViewModel.Common;
using System.Collections.Generic;

namespace ManaViewModel.Profile.PhoneNumberType
{
    public class PhoneNumberTypeVM : BaseVM<PhoneNumberTypeVM, Entities.Profile.PhoneNumberType.PhoneNumberType, int>
    {
        public string Description { get; set; }
        public IEnumerable<PhoneNumber.PhoneNumberVM> PhoneNumbers { get; set; }
    }
}