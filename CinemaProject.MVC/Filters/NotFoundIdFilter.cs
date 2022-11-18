using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CinemaProject.Core;

namespace CinemaProject.Web.Filters
{
    public class NotFoundIdFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericService<T> _service;

        public NotFoundIdFilter(IGenericService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var IdValue = context.ActionArguments.Values.FirstOrDefault();
            if (IdValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)IdValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }
            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(T)}{id} not found");
            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
        }
    }
}
