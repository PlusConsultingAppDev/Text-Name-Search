﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace App.Membership.Filters
{
    public class AddAuthorizeFiltersControllerConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.ControllerName.Contains("Token"))
            {
                controller.Filters.Add(new AuthorizeFilter("securepolicy"));
            }
        }
    }
}
