namespace KT.Presentation.Contracts.V1.Requests.CourseTemplates;

public record AddSessionPlanTemplateRequest(
    List<AddSessionTemplateRequest> SessionTemplates);