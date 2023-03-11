using Microsoft.AspNetCore.Mvc;

namespace InterApi.Controllers;

public class CommonResponse<T>
{
    public CommonResponse(T data)
    {
        Data = data;
    }
    public CommonResponse(string error)
    {
        this.Error = error;
        this.Success = false;
    }
    public bool Success { get; set; } = true;
    public string Error { get; set; }
    public T Data { get; set; }
}

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}

[ApiController]
[Route("interapi/v1.0/[controller]")]
public class StudentController : ControllerBase
{
    public StudentController()
    {

    }


    [HttpGet("GetSystemDate")]
    public CommonResponse<DateTime> GetSystemDate()
    {
        return new CommonResponse<DateTime>(DateTime.UtcNow);
    }

    [HttpGet]
    public CommonResponse<List<Student>> GetAll()
    {
        var list = GetStudentList();
        return new CommonResponse<List<Student>>(list);
    }

    [HttpGet("{id}")]
    public CommonResponse<Student> GetById([FromRoute] long id)
    {
        var list = GetStudentList();
        var student = list.Where(x => x.Id == id).FirstOrDefault();
        if (student is null)
        {
            return new CommonResponse<Student>("No data found!");
        }
        return new CommonResponse<Student>(student);
    }

    [HttpGet("GetByFilter")]
    public List<Student> GetByFilter([FromQuery] string name, string lastname)
    {
        var list = GetStudentList();
        var students = list.Where(x => x.Name.Contains(name) || x.Lastname.Contains(lastname)).ToList();
        return students;
    }

    [HttpPost]
    public List<Student> Post([FromBody] Student request)
    {
        var list = GetStudentList();
        list.Add(request);
        return list;
    }

    [HttpPut("{id}")]
    public List<Student> Put([FromRoute] long id, [FromBody] Student request)
    {
        request.Id = id;
        var list = GetStudentList();
        var student = list.Where(x => x.Id == id).FirstOrDefault();
        list.Remove(student);
        list.Add(request);
        return list;
    }

    [HttpDelete("{id}")]
    public List<Student> Delete([FromRoute] long id)
    {
        var list = GetStudentList();
        var student = list.Where(x => x.Id == id).FirstOrDefault();
        list.Remove(student);
        return list;
    }

    private List<Student> GetStudentList()
    {
        List<Student> list = new();
        list.Add(new Student { Id = 1, Age = 23, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });
        list.Add(new Student { Id = 2, Age = 24, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });
        list.Add(new Student { Id = 3, Age = 25, Email = "deny@sellen.com", Lastname = "Sellen", Name = "Deny" });

        return new List<Student>(list);
    }
}
