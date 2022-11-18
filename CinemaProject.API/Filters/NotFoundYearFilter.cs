using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.API.Filters
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
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"({year}) not found "));
        }
    }
}
