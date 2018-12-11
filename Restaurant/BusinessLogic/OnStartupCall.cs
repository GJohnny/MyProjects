using DAL.RepositoryPattern;
using DAL.RepositoryPattern.Context;
using DAL.RepositoryPattern.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public static class OnStartupCall
    {
        public static async void DeleteReservations(IApplicationBuilder builder)
        {
            Logic logic = (Logic)builder.ApplicationServices.GetRequiredService<IBusinessLogic>();
            await logic.DeleteReservation();
        }
    }
}
