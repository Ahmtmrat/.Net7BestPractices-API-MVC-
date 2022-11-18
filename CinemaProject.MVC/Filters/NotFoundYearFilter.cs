using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CinemaProject.Web.Filters
{
    public class NotFoundYearFilter : IAsyncActionFilter
    {
        private readonly ICinemaService _service;

        public NotFoundYearFilter(ICinemaService service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var yearValue = context.ActionArguments.Values.FirstOrDefault();
            if (yearValue == null)
            {
                await next.Invoke();
                return;
            }
            var year = (int)yearValue;
            var anyEntity = await _service.AnyAsync(x => x.Year == year);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{year} not found");
            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
