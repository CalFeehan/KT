using KT.Application.Common.Interfaces.Persistence;
using KT.Domain.Student;

namespace KT.Infrastructure.Persistence;

public class StudentRepository : Repository<Student>, IStudentRepository
{
}