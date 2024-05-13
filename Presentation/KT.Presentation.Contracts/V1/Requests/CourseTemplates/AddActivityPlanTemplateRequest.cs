namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;

public record AddActivityPlanTemplateRequest(
    List<AddActivityTemplateRequest> ActivityTemplates);