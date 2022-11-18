using CinemaProject.Core.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CinemaProject.Core.Services;
using CinemaProject.Core;

namespace CinemaProject.Web.Filters
{
    public class NotFoundDirectorFilter : IAsyncActionFilter
    {
        private readonly ICinemaService _service;

        public NotFoundDirectorFilter(ICinemaService service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var directorValue = context.ActionArguments.Values.FirstOrDefault();
            if (directorValue == null)
            {
                await next.Invoke();
                return;
            }
            var director = (string)directorValue;
            var anyEntity = await _service.AnyAsync(x => x.Director == director);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{director} not found");
            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
