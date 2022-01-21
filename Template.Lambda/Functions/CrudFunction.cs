namespace Template.Lambda.Functions;

using AmazonLambdaExtension.Annotations;

using AutoMapper;

using Template.Lambda.Parameters;
using Template.Models;
using Template.Services;

using Microsoft.Extensions.Logging;

[Lambda]
[ServiceResolver(typeof(HttpApiServiceResolver))]
[Filter(typeof(HttpApiFilter))]
public sealed class CrudFunction
{
    private readonly ILogger<CrudFunction> logger;

    private readonly IMapper mapper;

    private readonly DataService dataService;

    public CrudFunction(ILogger<CrudFunction> logger, IMapper mapper, DataService dataService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.dataService = dataService;
    }

    [HttpApi]
    public async ValueTask<CrudListOutput> List([FromQuery] string? token)
    {
        var result = await dataService.QueryDataListAsync(token, 20).ConfigureAwait(false);

        return new CrudListOutput { Entities = result.List, NextToken = result.Token };
    }

    [HttpApi]
    public async ValueTask<DataEntity?> Get([FromRoute] string id)
    {
        return await dataService.QueryDataAsync(id).ConfigureAwait(false);
    }

    [HttpApi]
    public async ValueTask<CrudCreateOutput> Create([FromBody] CrudCreateInput input)
    {
        var entity = mapper.Map<DataEntity>(input);
        entity.Id = Guid.NewGuid().ToString();
        entity.CreatedAt = DateTime.Now;

        await dataService.CreateDataAsync(entity).ConfigureAwait(false);

        logger.LogInformation("Data created. id=[{Id}]", entity.Id);

        return new CrudCreateOutput { Id = entity.Id };
    }

    [HttpApi]
    public async ValueTask Delete([FromRoute] string id)
    {
        await dataService.DeleteDataAsync(id).ConfigureAwait(false);

        logger.LogInformation("Data deleted. id=[{Id}]", id);
    }
}
