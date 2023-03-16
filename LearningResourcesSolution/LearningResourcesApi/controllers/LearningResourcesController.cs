using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;
    public LearningResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources(
        [FromBody] LearningResourcesCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // turn the request to a Domain.LearningResourcesEntity
        var entity = new LearningResourcesEntity
        {
            Name = request.Name,
            Description = request.Description,
            Link = request.Link,
            WhenCreated = DateTime.Now
        };
        // tell datacontext about it
        _context.LearningResources.Add(entity);
        // tell the datacontext to save the data
        await _context.SaveChangesAsync();
        // Return a Success Status Code*
        //   - With a copy of the brand new entity
        var response = new LearningResourceSummaryItem(entity.Id.ToString(), entity.Name, entity.Description, entity.Link);
        return Ok(response);
    }

    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources()
    {
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourceSummaryItem(item.Id.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync();
        var response = new LearningResourcesResponse(data);
        return Ok(response);
    }
}
