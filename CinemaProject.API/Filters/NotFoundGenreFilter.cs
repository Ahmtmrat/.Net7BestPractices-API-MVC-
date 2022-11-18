using Autofac.Core;
using CinemaProject.Core.DTOs;
using CinemaProject.Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.API.Filters
{
    public class NotFoundGenreFilter: IAsyncActionFilter 
    {
        private readonly ICinemaService _service;

    public NotFoundGenreFilter(ICinemaService service)
    {
        _service = service;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var genreValue = context.ActionArguments.Values.FirstOrDefault();
        if (genreValue == null)
        {
            await next.Invoke();
            return;
        }
        var genre = (string)genreValue;
        var anyEntity = await _service.AnyAsync(x => x.Genre == genre);

        if (anyEntity)
        {
            await next.Invoke();
            return;
        }
        context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"({genre}) not found "));
    }
}
}
