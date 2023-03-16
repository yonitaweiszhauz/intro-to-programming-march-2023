﻿using System.ComponentModel.DataAnnotations;

namespace LearningResourcesApi.Models; 

public record LearningResourceSummaryItem(
 string Id, string Name, string Description, string Link);

public record LearningResourcesResponse(List<LearningResourceSummaryItem>Data);

public record LearningResourcesCreateRequest : IValidatableObject
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;
    [Required, MaxLength(200)]
    public string Description { get; init; } = string.Empty;
    [Required]
    public string Link { get; init; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        if (Name.ToLowerInvariant().Contains("darth"))
        {
            yield return new ValidationResult("Sorry, we have a strict no platforming Sith Lords Policy");
        }
        if (Link.ToLowerInvariant().Contains("facebook"))
        {
            yield return new ValidationResult("No Facebook links please");
        }
    }
} 