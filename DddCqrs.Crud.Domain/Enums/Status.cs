namespace DddCqrs.Crud.Domain.Enums
{
    public enum Status
    {
        Duplicate = 7,
        Ok = 200,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500,
        ExternalServerError = 999,
        NotImplemented = 501,
    }
}